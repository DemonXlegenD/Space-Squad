using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPlayerGroup : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int percentOfGroup = 50;
    private Flock Flock;

    private List<FlockAgent> HealingAgents = new List<FlockAgent>();

    void Start()
    {
        Flock = GetComponent<Flock>();
    }

    public void ApplyHealingPlayer(Vector3 _target)
    {
        if (Flock != null)
        {
            if (IsEmptyHealing())
            {
                HealingAgents = Flock.GetCloserAgents(_target, percentOfGroup);
                foreach (FlockAgent flock_agent in HealingAgents)
                {
                    flock_agent.IsCurrentlyHealingPlayer = true;
                    //flock_agent.HealingPlayer.ApplyHealingPlayer();
                }
            }
            else
            {
                Debug.Log("Soigne deja le joueur");
            }
           
        }
        else
        {
            Debug.Log("Flock is necessary");
        }
    }

    /*
    public void ResetHealingPlayer()
    {
        foreach (FlockAgent flock_agent in HealingAgents)
        {
            flock_agent.HealingPlayer.StopHealingPlayer();
        }
        HealingAgents.Clear();
    }
    */

    public List<FlockAgent> GetHealingAgents()
    {
        return HealingAgents;
    }

    public bool IsEmptyHealing()
    {
        foreach (FlockAgent flock_agent in HealingAgents)
        {
            if (!flock_agent.IsCurrentlyHealingPlayer) 
            {
                HealingAgents.Remove(flock_agent);
            }
        }
        return HealingAgents.Count == 0;
    }
}
