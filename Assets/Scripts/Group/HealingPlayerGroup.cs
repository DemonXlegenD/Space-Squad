using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPlayerGroup : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int percentOfGroup = 50;
    private Flock Flock;
    void Start()
    {
        Flock = GetComponent<Flock>();
    }

    public void ApplyHealingPlayer(Vector3 _target)
    {
        if (Flock != null)
        {

            foreach (FlockAgent flock_agent in Flock.GetCloserAgents(_target, percentOfGroup))
            {
                flock_agent.HealingPlayer.ApplyHealingPlayer();
            }
        }
        else
        {
            Debug.Log("Flock is necessary");
        }
    }

    public void ResetHealingPlayer()
    {
        List<FlockAgent> flock_agents = Flock.FlockAgents;
        foreach (FlockAgent flock_agent in flock_agents)
        {
            flock_agent.HealingPlayer.StopHealingPlayer();
        }
    }
}
