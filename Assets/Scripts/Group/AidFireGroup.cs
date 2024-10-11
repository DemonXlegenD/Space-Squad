using System.Collections.Generic;
using UnityEngine;

public class AidFireGroup : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int percentOfGroup = 50;
    private Flock Flock;
    void Start()
    {
        Flock = GetComponent<Flock>();
    }

    public void ApplyAidFire(Vector3 _target)
    {
        if (Flock != null)
        {
            PlayerAgent player_agent = FindAnyObjectByType<PlayerAgent>();
            if (player_agent != null)
            {
                if (player_agent.IsInRangeAndNotTooClose(_target))
                {

                    foreach (FlockAgent flock_agent in Flock.GetCloserAgents(_target, percentOfGroup))
                    {
                        flock_agent.AidFire.ApplyAidFire(_target);
                    }
                }

            }
        }
        else
        {
            Debug.Log("Flock is necessary");
        }
    }

    public void ResetAidFire()
    {
        List<FlockAgent> flock_agents = Flock.FlockAgents;
        foreach (FlockAgent flock_agent in flock_agents)
        {
            flock_agent.AidFire.StopAidFiring();
        }
    }
}
