using System.Collections.Generic;
using UnityEngine;

public class ProtectGroup : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int percentOfGroup = 25;
    private Flock Flock;
    void Start()
    {
        Flock = GetComponent<Flock>();
    }

    public void ApplyProtectPlayer(Vector3 _target, Vector3 _offset)
    {
        if (Flock != null)
        {
            foreach (FlockAgent flock_agent in Flock.GetCloserAgents(_target, percentOfGroup))
            {
                flock_agent.ProtectPlayer.ApplyProtecting(_offset);
            }
        }
        else
        {
            Debug.Log("Flock is necessary");
        }
    }

    public void ResetProtectPlayer()
    {
        List<FlockAgent> flock_agents = Flock.FlockAgents;
        foreach (FlockAgent flock_agent in flock_agents)
        {
            flock_agent.ProtectPlayer.StopProtectingPlayer();
        }
    }
}
