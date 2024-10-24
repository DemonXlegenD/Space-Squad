using FSMMono;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Role 
{
    private FlockAgent agent;
    private AIAgent AIAgent;
    private PlayerAgent playerAgent;

    private Vector3 offset = Vector3.zero;
    public Vector3 Offset { get { return offset; } set { offset = value; } }

    private bool isHealing = false;
    public bool IsHealing { get { return isHealing; } set { isHealing = value; } }

    protected override void Start()
    {
        base.Start();
        agent = GetComponent<FlockAgent>();
        AIAgent = GetComponent<AIAgent>();
        playerAgent = FindAnyObjectByType<PlayerAgent>();
    }

    public void NPCHealPlayer() 
    {
        playerAgent.CharacterHealth.Healing(10f);
        
        if (playerAgent.CharacterHealth.IsMaxHealth())
        {
            agent.IsCurrentlyHealingPlayer = false;
        }
    }

    public void CheckIfNPCIsHealing() 
    {
        if (playerAgent.CharacterHealth.IsMaxHealth())
        {
            agent.IsCurrentlyHealingPlayer = false;
        }
    }
}