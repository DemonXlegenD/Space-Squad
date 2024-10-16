using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_StartFireCoverNode : ActionNode
{
    [SerializeField] Flock flock;

    #region Overrides of Node
    protected override void OnStart() {}

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        return State.Success;
    }
    #endregion
}
