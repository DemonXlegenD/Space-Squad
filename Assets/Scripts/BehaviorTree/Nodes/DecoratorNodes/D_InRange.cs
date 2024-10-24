using FSMMono;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_InRange : DecoratorNode
{
    protected override void OnStart() {}

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        Vector3 target = Tree.Data.GetValue<GameObject>(DataKey.TARGET_FIRING).transform.position;
        if (npc.GetComponent<AIAgent>().IsInRangeAndNotTooClose(target))
        {
            return child.UpdateNode();
        }
        return State.Failure;
    }
}
