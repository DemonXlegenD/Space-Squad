using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMMono;
public class A_CoverFireNode : ActionNode
{
    #region Overrides of Node
    protected override void OnStart() {}

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        npc.GetComponent<FlockAgent>().CoverFire.NPCShootToTarget((Tree.Data.GetValue<GameObject>(DataKey.TARGET_COVER)).transform.position);
        return State.Running;
    }

    #endregion
}

