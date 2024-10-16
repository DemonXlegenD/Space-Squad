using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_ReformationNode : ActionNode
{
    [SerializeField] Flock flock;
    public bool shouldReset = false;

    #region Overrides of Node
    protected override void OnStart() 
    {
        npc = FindParentWithTag(transform, "NPC");
    }

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        if (shouldReset) 
        {
            npc.GetComponent<FlockAgent>().ResetFlock();
            return State.Success;
        }

        return State.Running;
    }

    #endregion
}
