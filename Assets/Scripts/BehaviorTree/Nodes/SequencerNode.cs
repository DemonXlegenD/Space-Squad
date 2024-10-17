using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerNode : CompositeNode
{
    private int currentNodeID;

    protected override void Start()
    {
        base.Start();
        foreach (Transform child in transform) 
        {
            children.Add(child.GetComponent<Node>());
        }
    }

    #region Overrides of Node

    protected override void OnStart()
    {
        currentNodeID = 0;
    }

    protected override void OnStop() { }

    protected override State OnUpdate() 
    {
        if (children == null && children.Count < 1)
        {
            Debug.LogWarning("Sequencer Node has no children.");
            return State.Failure;
        }

        switch (children[currentNodeID].UpdateNode())
        {
            case State.Running:
                //Debug.Log(currentNodeID);
                return State.Running;
            case State.Success:
                currentNodeID++;
                break;
            case State.Failure:
                return State.Failure;
            default:
                return State.Failure;
        }

        return currentNodeID == children.Count ? State.Success : State.Running;
    }

    #endregion
}