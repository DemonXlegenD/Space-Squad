using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelNode : CompositeNode
{
    [SerializeField] private bool requireAllSuccess = false;

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        bool anyChildRunning = false;
        State state = State.Running;

        foreach (Node child in children)
        {
            State childState = child.UpdateNode();

            if (childState == State.Running)
            {
                anyChildRunning = true;
            }
            else if (childState == State.Failure && requireAllSuccess)
            {
                state = State.Failure;
                return state;
            }
        }

        if (requireAllSuccess && !anyChildRunning)
        {
            state = State.Success;
        }
        else
        {
            state = State.Running;
        }

        return state;
    }
}

