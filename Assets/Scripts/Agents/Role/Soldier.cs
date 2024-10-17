using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Role
{

    [SerializeField] private Color color = Color.gray;
    protected override void Start()
    {
        base.Start();
        SetColorToMaterial(color);
    }
}
