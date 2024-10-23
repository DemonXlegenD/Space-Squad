using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_HealNode : ActionNode
{
    #region Overrides of Node
    protected override void OnStart() 
    {
        npc = FindParentWithTag(transform, "NPC");
    }

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        if (Vector3.Distance((Tree.Data.GetValue<PlayerAgent>(DataKey.PLAYER)).transform.position, npc.transform.position) <= 3f)
        {
            Debug.Log("HEALINGUUU");
            npc.GetComponent<FlockAgent>().HealingPlayer.NPCHealPlayer();
            return State.Success;
        } else {
            npc.GetComponent<FlockAgent>().HealingPlayer.CheckIfNPCIsHealing();
            return State.Failure;
        }
    }

    #endregion
}

