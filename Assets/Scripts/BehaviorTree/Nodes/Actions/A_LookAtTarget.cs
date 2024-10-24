using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_LookAtTarget : ActionNode
{
    #region Overrides of Node
    protected override void OnStart() { }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        Vector3 objectif = (Tree.Data.GetValue<PlayerAgent>(DataKey.PLAYER)).transform.position + npc.GetComponent<Guardian>().OffsetCheck.offset * 2;
        objectif.y = npc.transform.position.y;
        npc.transform.LookAt(objectif);

        return State.Success;
    }

    #endregion
}
