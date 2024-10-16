using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionNode : Node 
{
    public Transform npc;

    public static Transform FindParentWithTag(Transform self_transform, string tag)
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
