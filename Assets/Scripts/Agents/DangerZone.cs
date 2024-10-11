using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DangerZone : MonoBehaviour
{
    private Collider DangerCollider;

    [SerializeField] private LayerMask BulletMask;
    // Start is called before the first frame update
    void Start()
    {
        DangerCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && ((1 << other.gameObject.layer) & BulletMask) != 0)
        {
            Debug.Log("ALERTE GENERALE");
        }
    }
}
