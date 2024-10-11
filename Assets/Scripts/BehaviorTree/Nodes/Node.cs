using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour 
{
    public enum State
    {
        Running,
        Success,
        Failure
    }

    [SerializeField] private State state = State.Running;
    [SerializeField] private bool started;

    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract State OnUpdate();

    public State UpdateNode()
    {
        if (!started)
        {
            OnStart();
            started = true;
        }

        state = OnUpdate();

        if (state == State.Failure || state == State.Success)
        {
            OnStop();
            started = false;
        }

        return state;
    }
}
