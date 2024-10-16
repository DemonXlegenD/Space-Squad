using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_CoverFireNode : ActionNode
{
    #region Overrides of Node
    protected override void OnStart() 
    {
        npc = FindParentWithTag(transform, "NPC");
    }

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        return State.Success;
    }

    #endregion
}

