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
            foreach (FlockAgent flock_agent in GetCloserAgents(_target))
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

    public List<FlockAgent> GetCloserAgents(Vector3 _target)
    {
        List<FlockAgent> flock_agents = Flock.FlockAgents;
        Dictionary<float, FlockAgent> distanceToNPCMap = new Dictionary<float, FlockAgent>(flock_agents.Count);

        foreach (FlockAgent flock_agent in flock_agents)
        {
            distanceToNPCMap.Add(flock_agent.CoverFire.DistanceToTarget(_target), flock_agent);
        }

        int countToRetrieve = Mathf.CeilToInt(distanceToNPCMap.Count * percentOfGroup / 100);

        Debug.Log(distanceToNPCMap.Count);
        return distanceToNPCMap
            .OrderBy(kvp => kvp.Key)
            .Take(countToRetrieve)
            .Select(pair => pair.Value)
            .ToList();
    }
}
