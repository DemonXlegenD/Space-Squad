using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DangerZone : MonoBehaviour
{
    private Collider DangerCollider;
    private Flock flock;

    [SerializeField] private LayerMask BulletMask;
    // Start is called before the first frame update
    void Start()
    {
        DangerCollider = GetComponent<Collider>();
        flock = FindAnyObjectByType<Flock>();
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other != null && ((1 << _other.gameObject.layer) & BulletMask) != 0)
        {
            Debug.Log("Danger");
            flock.ProtectGroup.ApplyProtectPlayer(_other.transform.position,GetProtectionPos(_other.transform.position));
        }
    }

    private Vector3 GetProtectionPos(Vector3 _target)
    {
        return _target - transform.position;
    }
}
