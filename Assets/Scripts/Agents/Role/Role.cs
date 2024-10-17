using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour
{
    private Renderer bodyRenderer ;
    protected virtual void Start()
    {
        Transform bodyTransform = transform.Find("Body");
        bodyRenderer = bodyTransform.GetComponent<Renderer>();
    }

    protected void SetColorToMaterial(Color color)
    {
        bodyRenderer.material.color = color;
    }
}
