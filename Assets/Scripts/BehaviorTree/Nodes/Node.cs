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

    public BehaviorTreeRunner Tree;

    protected virtual void Start()
    {
        Tree = FindParentWithTag(transform, "Tree").GetComponent<BehaviorTreeRunner>();
    }

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
        Debug.Log(this.name);
        state = OnUpdate();

        if (state == State.Failure || state == State.Success)
        {
            OnStop();
            started = false;
        }

        return state;
    }

    public Transform FindParentWithTag(Transform self_transform, string tag)
    {
        Transform t = self_transform;
        while (t.parent != null)
        {
            if (t.parent.tag == tag)
            {
                return t.parent.transform;
            }
            t = t.parent.transform;
        }
        return null;
    }
}
