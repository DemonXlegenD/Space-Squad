using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_ReformationNode : ActionNode
{
    [SerializeField] Flock flock;

    #region Overrides of Node
    protected override void OnStart() {}

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        flock.Recalculate();
        return State.Success;
    }

    #endregion
}
