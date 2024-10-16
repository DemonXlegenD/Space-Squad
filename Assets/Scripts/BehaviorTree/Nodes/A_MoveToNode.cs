using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_MoveToNode : ActionNode
{
    public enum MoveToLocation{
        PLAYER,
    }

    private MoveToLocation CurrentMoveToLocation = MoveToLocation.PLAYER;

    #region Overrides of Node
    protected override void OnStart() 
    {
        npc = FindParentWithTag(transform, "NPC");
        Tree = FindParentWithTag(transform, "Tree").GetComponent<BehaviorTreeRunner>();
    }

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        switch (CurrentMoveToLocation)
        {
            case MoveToLocation.PLAYER:
                npc.GetComponent<FlockAgent>().MoveTo(((GameObject)Tree.Data.GetData(DataKey.PLAYER)).transform.position + npc.GetComponent<FlockAgent>().Offset);
                return State.Running;
            default:
                break;
        }

        return State.Failure;
    }

    #endregion
}

