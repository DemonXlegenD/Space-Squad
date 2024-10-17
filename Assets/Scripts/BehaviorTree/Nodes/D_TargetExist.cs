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
        if (npc.GetComponent<FlockAgent>().Target != Vector3.zero) 
        {
            return State.Success;
        }

        return State.Failure;
    }

    #endregion
}
