using System.Collections.Generic;
using UnityEngine;

public class CoverFireGroup : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int percentOfGroup = 50;
    private Flock Flock;

    [SerializeField]
    GameObject NPCTargetCursorPrefab = null;
    GameObject NPCTargetCursor = null;



    void Start()
    {
        Flock = GetComponent<Flock>();
    }


    private GameObject GetNPCTargetCursor()
    {
        if (NPCTargetCursor == null)
        {
            NPCTargetCursor = Instantiate(NPCTargetCursorPrefab);
        }
        return NPCTargetCursor;
    }

    public void NPCShootToPosition(Vector3 _pos)
    {
        Debug.Log("call");
        if (NPCTargetCursor == null){ 
            GetNPCTargetCursor().transform.position = _pos;
            ApplyCoverFire(_pos);
        }
        else{
            Destroy(NPCTargetCursor);
            ResetCoverFire();
        }
    }

    public void ApplyCoverFire(Vector3 _target)
    {
        if (Flock != null)
        {
            ResetCoverFire();
            foreach (FlockAgent flock_agent in Flock.GetCloserAgents(_target, percentOfGroup))
            {
                flock_agent.StopFlocking();
                flock_agent.CoverFire.ApplyCoverFire(_target);
            }
        }
        else
        {
            Debug.Log("Flock is necessary");
        }
    }

    public void ResetCoverFire()
    {
        List<FlockAgent> flock_agents = Flock.FlockAgents;
        foreach (FlockAgent flock_agent in flock_agents)
        {
            flock_agent.CoverFire.StopCoverFiring();
        }
    }
}
