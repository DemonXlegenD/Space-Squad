using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : CompositeNode
{
    private int currentNodeID;
    [SerializeField] bool ROOT = false;
    protected override void Start()
    {
        base.Start();
    }

    #region Overrides of Node
    protected override void OnStart()
    {
        currentNodeID = 0;
    }

    protected override void OnStop() {}

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
                return State.Running;
            case State.Success:
                currentNodeID = 0;
                return State.Running;
                break;
            case State.Failure:
                currentNodeID++;
                break;
            default:
                return State.Failure;
        }

        if (ROOT) 
        {
            if (currentNodeID >= children.Count) 
            {
                currentNodeID = 0;
            }
            return State.Running;
        } else {
            return currentNodeID == children.Count ? State.Failure : State.Running;
        }
    }

    #endregion
}
