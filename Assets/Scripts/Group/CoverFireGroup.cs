using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverFireGroup : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int percentOfGroup = 50;
    [SerializeField] public BlackBoard Data;
    private Flock Flock;

    [SerializeField] GameObject NPCTargetCursorPrefab = null;
    GameObject NPCTargetCursor = null;

    List<FlockAgent> CoveringAgents = new List<FlockAgent>();

    void Start()
    {
        Flock = GetComponent<Flock>();
        GetNPCTargetCursor().SetActive(false);
        Data.AddData(DataKey.TARGET_COVER, NPCTargetCursor);
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
        if (!NPCTargetCursor.activeSelf)
        {
            NPCTargetCursor.SetActive(true);
            GetNPCTargetCursor().transform.position = _pos;
            ApplyCoverFire(_pos);
        }
        else
        {
            //Destroy(NPCTargetCursor);
            NPCTargetCursor.SetActive(false);
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
                //flock_agent.StopFlocking();
                //flock_agent.CoverFire.ApplyCoverFire(_target);
                flock_agent.IsCurrentlyCoverFiring = true;
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
            //flock_agent.CoverFire.StopCoverFiring();
            flock_agent.IsCurrentlyCoverFiring = false;
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

    private  IEnumerator Test()
    {
        yield return null;
    } 
}
