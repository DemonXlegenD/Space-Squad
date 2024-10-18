using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : Role
{
    public OffsetCheck OffsetCheck = null;
    [SerializeField] private Color color = Color.yellow;
    protected override void Start()
    {
        base.Start();
        SetColorToMaterial(color);
    }

    public void AttributeOffset(OffsetCheck _offsetCheck)
    {
        OffsetCheck = _offsetCheck;
    }

    public bool HasOffset()
    {
        return OffsetCheck != null;
    }

    public void DeleteOffset()
    {
        OffsetCheck = null; 
    }
}
