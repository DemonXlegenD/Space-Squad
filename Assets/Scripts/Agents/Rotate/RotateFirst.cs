using UnityEngine;

public class RotateFirst : RotateArm
{
    public override void AimTo(Vector3 _pos)
    {
        // Calcul de la direction vers la cible en conservant l'axe Y
        Vector3 direction = (endArmTransform.position - _pos).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        transform.rotation = targetRotation;
    }
}
