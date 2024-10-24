using FSMMono;
using UnityEngine;

public class A_MoveToNode : ActionNode
{
    public enum MoveToLocation
    {
        PLAYER,
        TARGET_PROTECT,
        TARGET_COVER,
        TARGET_HEAL,
    }

    [SerializeField] private MoveToLocation CurrentMoveToLocation = MoveToLocation.PLAYER;

    #region Overrides of Node
    protected override void OnStart() { }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        Vector3 target = Vector3.zero;
        float stop_dist = -1.0f;

        switch (CurrentMoveToLocation)
        {
            case MoveToLocation.PLAYER:
                target = (Tree.Data.GetValue<PlayerAgent>(DataKey.PLAYER)).transform.position + npc.GetComponent<FlockAgent>().Offset;
                stop_dist = 0.01f;
                break;

            case MoveToLocation.TARGET_COVER:
                target = (Tree.Data.GetValue<GameObject>(DataKey.TARGET_COVER)).transform.position;
                stop_dist = npc.GetComponent<AIAgent>().Gun.MaxRange;
                break;

            case MoveToLocation.TARGET_PROTECT:
                target = (Tree.Data.GetValue<PlayerAgent>(DataKey.PLAYER)).transform.position + npc.GetComponent<Guardian>().OffsetCheck.offset * 2;
                stop_dist = 3f;
                Vector3 objectif = (Tree.Data.GetValue<PlayerAgent>(DataKey.PLAYER)).transform.position + npc.GetComponent<Guardian>().OffsetCheck.offset * 2;
                objectif.y = npc.transform.position.y;
                npc.transform.LookAt(objectif);
                break;

            case MoveToLocation.TARGET_HEAL:
                target = (Tree.Data.GetValue<PlayerAgent>(DataKey.PLAYER)).transform.position;
                stop_dist = 3f;
                break;

            default:
                break;
        }

        if (target != Vector3.zero && npc.GetComponent<FlockAgent>().DistanceToTarget(target) > stop_dist && stop_dist != -1.0f)
        {
            npc.GetComponent<FlockAgent>().MoveTo(target);
            return State.Running;
        }
        else if (npc.GetComponent<FlockAgent>().DistanceToTarget(target) <= stop_dist && stop_dist != -1.0f)
        {
            npc.GetComponent<AIAgent>().StopMove();
            return State.Success;
        }

        return State.Failure;
    }

    #endregion
}

