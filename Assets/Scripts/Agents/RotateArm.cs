using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class RotateArm : MonoBehaviour
{

    [SerializeField] protected Transform endArmTransform;
    public abstract void AimTo(Vector3 _pos);

    private void OnDrawGizmos()
    {
        // Définir la position de départ du bras
        Vector3 position = transform.position;

        // Dessiner le vecteur forward (bleu)
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(position, position + transform.forward * 2.0f); // Ajuste la longueur selon ton besoin

        // Dessiner le vecteur up (vert)
        Gizmos.color = Color.green;
        Gizmos.DrawLine(position, position + transform.up * 2.0f);

        // Dessiner le vecteur right (rouge)
        Gizmos.color = Color.red;
        Gizmos.DrawLine(position, position + transform.right * 2.0f);
    }
}
