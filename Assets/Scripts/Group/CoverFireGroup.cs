using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoverFireGroup : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int percentOfGroup = 50;
    private Flock Flock;
    void Start()
    {
        Flock = GetComponent<Flock>();
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
