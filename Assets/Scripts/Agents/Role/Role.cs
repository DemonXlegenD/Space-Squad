using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour
{
    private Material bodyMaterial;
    protected virtual void Start()
    {
        bodyMaterial = GetComponentInChildren<Material>();
    }

    protected void SetColorToMaterial(Color color)
    {
        bodyMaterial.color = color;
    }
}
