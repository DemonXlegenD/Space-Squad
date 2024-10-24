using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatNode : DecoratorNode
{
    #region Overrides of Node

    protected override void OnStart() { }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        State currenChildState = child.UpdateNode();

        return State.Running;
    }

    #endregion
}