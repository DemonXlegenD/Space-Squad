using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : Role
{

    [SerializeField] private Color color = Color.yellow;
    protected override void Start()
    {
        base.Start();
        SetColorToMaterial(color);
    }
}
