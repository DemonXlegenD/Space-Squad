using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_LowHPPlayer : DecoratorNode
{
    #region Overrides of Node

    protected override void OnStart() {}

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        if ((Tree.Data.GetValue<PlayerAgent>(DataKey.PLAYER)).CharacterHealth.IsLowHealth() || npc.GetComponent<FlockAgent>().IsCurrentlyHealingPlayer) // If character health is low
        {
            if(npc.GetComponent<FlockAgent>().IsCurrentlyHealingPlayer) // If npc is one of the closest to the target
            {
                return child.UpdateNode();
            }
        }
        return State.Failure;
    }

    #endregion
}
