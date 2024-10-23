using UnityEngine;

public class D_TickForcedState : DecoratorNode
{
    public enum ForcedState
    {
        NONE,
        SUCCESS,
        FAILURE,
        RUNNING,
    }

    public ForcedState forcedState = ForcedState.NONE;

    [SerializeField] private float TimerForced = 1f;
    private float currentTimer = 0f;

    protected override void OnStart()
    {
        currentTimer = 0f;
    }

    protected override void OnStop()
    {
        currentTimer = 0f;
    }

    protected override State OnUpdate()
    {
        State state = child.UpdateNode();
        currentTimer += Tree.CurrentTimer;
        if (currentTimer > TimerForced)
        {
            currentTimer = 0f;
            switch (forcedState)
            {
                case ForcedState.RUNNING:
                    return State.Running;
                case ForcedState.SUCCESS:
                    return State.Success;
                case ForcedState.FAILURE:
                    return State.Failure;
                default:
                    return State.Failure;
            }
        }
        return state;
    }
}
