using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_MoveToNode : ActionNode
{
    public enum MoveToLocation{
        PLAYER,
        TARGET,
    }

    [SerializeField] private MoveToLocation CurrentMoveToLocation = MoveToLocation.PLAYER;

    protected override void Start()
    {
        base.Start();
    }

    #region Overrides of Node
    protected override void OnStart() 
    {
    }

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        switch (CurrentMoveToLocation)
        {
            case MoveToLocation.PLAYER:
                Debug.Log("Move to player");
                npc.GetComponent<FlockAgent>().MoveTo((Tree.Data.GetValue<PlayerAgent>(DataKey.PLAYER)).transform.position + npc.GetComponent<FlockAgent>().Offset);
                return State.Running;
            case MoveToLocation.TARGET:
                return State.Running;
            default:
                break;
        }

        return State.Failure;
    }

    #endregion
}

