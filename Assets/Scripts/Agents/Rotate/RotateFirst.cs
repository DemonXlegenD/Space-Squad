using UnityEngine;

public class RotateFirst : RotateArm
{
    public override void AimTo(Vector3 _pos)
    {
        Vector3 direction = (endArmTransform.position - _pos).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        transform.rotation = targetRotation;
    }
}
