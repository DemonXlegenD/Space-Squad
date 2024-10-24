using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_TargetExist : DecoratorNode
{
    #region Overrides of Node
    
    protected override void OnStart() {}

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        if ((Tree.Data.GetValue<GameObject>(DataKey.TARGET_COVER)).activeSelf) // If target is active = If there is a target for the cover fire
        {
            if(npc.GetComponent<FlockAgent>().IsCurrentlyCoverFiring) // If npc is one of the closest to the target
            {
                return child.UpdateNode();
            }
        }

        return State.Failure;
    }

    #endregion
}
