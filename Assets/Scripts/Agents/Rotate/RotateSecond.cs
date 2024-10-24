using UnityEngine;

public class RotateSecond : RotateArm
{
    public override void AimTo(Vector3 _pos)
    {
        Vector3 direction = (endArmTransform.position - _pos).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.right);

        transform.rotation = targetRotation;
    }
}
