using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_HasOffsetTarget : DecoratorNode
{
    #region Overrides of Node
    protected override void OnStart() { }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {

        if(npc.GetComponent<Guardian>().HasOffset())
        {
            Debug.Log("HasOffset");
            return child.UpdateNode();
        }

        return State.Failure;
    }

    #endregion
}
