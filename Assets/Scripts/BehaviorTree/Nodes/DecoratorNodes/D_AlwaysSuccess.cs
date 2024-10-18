using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_AlwaysSuccess : DecoratorNode
{
    #region Overrides of Node
    protected override void OnStart() { }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        child.UpdateNode();

        return State.Success;
    }

    #endregion
}
