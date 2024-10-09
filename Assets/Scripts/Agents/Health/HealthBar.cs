using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform cameraTransform;

    private void Start()
    {
        // Récupérer la caméra principale de la scène
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
