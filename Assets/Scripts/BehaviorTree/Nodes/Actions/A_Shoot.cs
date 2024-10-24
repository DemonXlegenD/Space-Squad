using FSMMono;
using UnityEngine;

public class A_Shoot : ActionNode
{
    public enum ShootTarget
    {
        NONE,
        PLAYER,
        TARGET_COVER,
        TARGET_FIRING,
    }

    public ShootTarget Target = ShootTarget.NONE;

    protected override void OnStart() { }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        Vector3 target;
        switch (Target)
        {
            case ShootTarget.NONE:
                return State.Failure;
            case ShootTarget.PLAYER:
                target = Tree.Data.GetValue<GameObject>(DataKey.PLAYER).transform.position;
                break;
            case ShootTarget.TARGET_COVER:
                target = Tree.Data.GetValue<GameObject>(DataKey.TARGET_COVER).transform.position;
                break;
            case ShootTarget.TARGET_FIRING:
                target = Tree.Data.GetValue<GameObject>(DataKey.TARGET_FIRING).transform.position;
                break;
            default:
                return State.Failure;
        }
        npc.GetComponent<AIAgent>().ShootToPosition(target);

        return State.Success;
    }
}
