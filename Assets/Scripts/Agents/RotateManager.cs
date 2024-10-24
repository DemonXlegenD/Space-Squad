using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    public List<RotateArm> arms;

    public void Rotate(Vector3 _pos)
    {
        foreach (var arm in arms)
        {
            arm.AimTo(_pos);
        }
    }
}
