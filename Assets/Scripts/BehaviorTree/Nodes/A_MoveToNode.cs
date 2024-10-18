using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMMono;

public class A_MoveToNode : ActionNode
{
    public enum MoveToLocation{
        PLAYER,
        TARGET_COVER,
    }

    [SerializeField] private MoveToLocation CurrentMoveToLocation = MoveToLocation.PLAYER;

    protected override void Start()
    {
        base.Start();
    }

    #region Overrides of Node
    protected override void OnStart() {}

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        Vector3 target_ = Vector3.zero;
        float stopDist = -1.0f;

        switch (CurrentMoveToLocation)
        {
            case MoveToLocation.PLAYER:
                Debug.Log("Move to player");
                target_ = (Tree.Data.GetValue<PlayerAgent>(DataKey.PLAYER)).transform.position + npc.GetComponent<FlockAgent>().Offset;
                stopDist = 5.0f;
                break;
            case MoveToLocation.TARGET_COVER:
                target_ = (Tree.Data.GetValue<GameObject>(DataKey.TARGET_COVER)).transform.position;
                stopDist = npc.GetComponent<AIAgent>().Gun.MaxRange;
                break;
            default:
                break;
        }

        if (target_ != Vector3.zero && npc.GetComponent<FlockAgent>().DistanceToTarget(target_) > stopDist && stopDist != -1.0f)
        {
            npc.GetComponent<FlockAgent>().MoveTo(target_);
            return State.Running;
        } else if (npc.GetComponent<FlockAgent>().DistanceToTarget(target_) <= stopDist && stopDist != -1.0f) 
        {
            npc.GetComponent<AIAgent>().StopMove();
            return State.Success;
        }

        return State.Failure;
    }

    #endregion
}

