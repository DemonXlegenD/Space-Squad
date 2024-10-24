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
        Vector3 position = transform.position;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(position, position + transform.forward * 2.0f);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(position, position + transform.up * 2.0f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(position, position + transform.right * 2.0f);
    }
}
