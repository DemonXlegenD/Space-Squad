using System.Collections.Generic;
using UnityEngine;

public class ProtectGroup : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int percentOfGroup = 25;
    private Flock Flock;
    private List<FlockAgent> ProtectingAgents = new List<FlockAgent>();
    void Start()
    {
        Flock = GetComponent<Flock>();
    }

    public void ApplyProtectPlayer(Vector3 _target, Vector3 _offset)
    {
        if (Flock != null)
        {
            if (IsEmptyProtecting())
            {
                ProtectingAgents = Flock.GetCloserAgents(_target, percentOfGroup);
                foreach (FlockAgent flock_agent in ProtectingAgents)
                {
                    flock_agent.ProtectPlayer.ApplyProtecting(_offset);
                }
            }
            else
            {
                foreach (FlockAgent flock_agent in ProtectingAgents)
                {
                    flock_agent.ProtectPlayer.ChangeOffset(_offset);
                }
            }

        }
    }

    public void ResetProtectPlayer()
    {
        foreach (FlockAgent flock_agent in ProtectingAgents)
        {
            flock_agent.ProtectPlayer.StopProtectingPlayer();
        }
        ProtectingAgents.Clear();
    }

    public List<FlockAgent> GetProtectingAgents()
    {
        return ProtectingAgents;
    }

    public bool IsEmptyProtecting()
    {
        return ProtectingAgents.Count == 0;
    }
}
