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
        if ((Tree.Data.GetValue<GameObject>(DataKey.TARGET_COVER)).activeSelf) 
        {
            if(npc.GetComponent<FlockAgent>().IsCurrentlyCoverFiring) 
            {
                Debug.Log("IsCurrentlyCoverFiring");
                return child.UpdateNode();
            }
        }

        return State.Failure;
    }

    #endregion
}
