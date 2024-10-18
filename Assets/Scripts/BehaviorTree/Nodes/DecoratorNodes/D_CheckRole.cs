using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_CheckRole : DecoratorNode
{

    public enum Role
    {
        NONE,
        GUARDIAN,
        SOLDIER,
        HEALER
    }

    public Role role = Role.NONE;

    #region Overrides of Node

    protected override void OnStart()
    {
    }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        switch (role)
        {
            case Role.NONE:
                return child.UpdateNode();
            case Role.GUARDIAN:
                if(npc.GetComponent<Guardian>() != null) return child.UpdateNode();
                break;
            case Role.HEALER:
                if (npc.GetComponent<Healer>() != null) return child.UpdateNode();
                break;
            case Role.SOLDIER:
                if (npc.GetComponent<Soldier>() != null) return child.UpdateNode();
                break;
            default:
                break;
        }
        return State.Failure;
    }

    #endregion


}
