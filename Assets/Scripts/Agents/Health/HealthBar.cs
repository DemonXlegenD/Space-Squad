using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform cameraTransform;

    private void Start()
    {
        // R�cup�rer la cam�ra principale de la sc�ne
        cameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        if (cameraTransform != null)
        {
            transform.LookAt(transform.position + cameraTransform.forward);
        }
    }
}
