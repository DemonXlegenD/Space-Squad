using System.Collections.Generic;
using UnityEngine;

public class CoverFireGroup : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int percentOfGroup = 50;
    private Flock Flock;

    [SerializeField]
    GameObject NPCTargetCursorPrefab = null;
    GameObject NPCTargetCursor = null;

    List<FlockAgent> CoveringAgents = new List<FlockAgent>();

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
        if (NPCTargetCursor == null)
        {
            GetNPCTargetCursor().transform.position = _pos;
            ApplyCoverFire(_pos);
        }
        else
        {
            Destroy(NPCTargetCursor);
            ResetCoverFire();
        }
    }

    public void ApplyCoverFire(Vector3 _target)
    {
        if (Flock != null)
        {
            CoveringAgents = Flock.GetCloserAgents(_target, percentOfGroup);
            foreach (FlockAgent flock_agent in CoveringAgents)
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
        foreach (FlockAgent flock_agent in CoveringAgents)
        {
            flock_agent.CoverFire.StopCoverFiring();
        }
        CoveringAgents.Clear();
    }

    public List<FlockAgent> GetCoveringAgents()
    {
        return CoveringAgents;
    }

    public bool IsEmptyCovering()
    {
        return CoveringAgents.Count == 0;
    }
}
