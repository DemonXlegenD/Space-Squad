using System.Collections.Generic;
using UnityEngine;

public abstract class CompositeNode : Node
{
    public List<Node> children = new List<Node>();

    protected override void Start()
    {
        base.Start();
        foreach (Transform child in transform)
        {
            children.Add(child.GetComponent<Node>());
        }
    }
}