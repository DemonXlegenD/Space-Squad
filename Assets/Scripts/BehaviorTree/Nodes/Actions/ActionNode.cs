using UnityEngine;

public abstract class ActionNode : Node
{
    public Transform npc;

    protected override void Start()
    {
        base.Start();
        npc = FindParentWithTag(transform, "NPC");
    }
}
