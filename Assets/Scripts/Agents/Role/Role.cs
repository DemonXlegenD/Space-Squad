using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour
{
    protected virtual void Start()
    {
        Transform bodyTransform = transform.Find("Body");
    }
}
