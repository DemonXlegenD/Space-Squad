using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecoratorNode : Node
{
    public Transform npc;

    public Node child;

    protected override void Start() 
    {
        base.Start();
        npc = FindParentWithTag(transform, "NPC");
        child = transform.GetChild(0).GetComponent<Node>();     

        if (child == null)
        {
            Debug.LogError("Child missing");
        }
    }

}
