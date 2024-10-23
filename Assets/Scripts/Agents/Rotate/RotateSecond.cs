using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSecond : RotateArm
{
    public override void AimTo(Vector3 _pos)
    {
        // Calcul de la direction vers la cible en conservant l'axe Y
        Vector3 direction = (endArmTransform.position - _pos).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.right);

        transform.rotation = targetRotation;
    }
}
