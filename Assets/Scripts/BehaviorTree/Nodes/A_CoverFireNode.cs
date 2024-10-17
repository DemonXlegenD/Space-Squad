using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_CoverFireNode : ActionNode
{
    #region Overrides of Node
    protected override void OnStart() {}

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        //npc.GetComponent<FlockAgent>().Target;
        return State.Success;
    }

    #endregion
}

