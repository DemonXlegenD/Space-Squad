using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelNode : CompositeNode
{
    [SerializeField] public List<D_Delay> DelayNodeToReset = new List<D_Delay>();

    protected override void OnStart() {}

    protected override void OnStop() {}

    protected override State OnUpdate()
    {
        bool anyChildRunning = false;
        State state = State.Running;

        foreach (Node child in children)
        {
            State childState = child.UpdateNode();

            if (childState == State.Running)
            {
                if (child is not D_Delay) 
                {
                    foreach (D_Delay delay in DelayNodeToReset) 
                    {
                        delay.RESET = true;
                    }
                }
                anyChildRunning = true;
            }
            else if (childState == State.Failure)
            {
                state = State.Failure;
                return state;
            }
        }

        if (!anyChildRunning)
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

