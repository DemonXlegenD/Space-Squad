using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Player : DecoratorNode
{
    #region Overrides of Node
    protected override void OnStart() {}

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        return State.Success;
    }

    #endregion
}
