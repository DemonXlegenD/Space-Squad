using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAgent : Entity
{

    [SerializeField] private LayerMask layers;

    [SerializeField]
    float ShootFrequency = 1f;

    float NextShootDate = 0f;


    int CurrentHP;

    GameObject Target = null;


    void Update()
    {
        if (Target && Time.time >= NextShootDate)
        {
            NextShootDate = Time.time + ShootFrequency;
            ShootToPosition(Target.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Target == null && ((1 << other.gameObject.layer) & layers) != 0)
        {
            Target = other.gameObject;
          
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (Target != null && other.gameObject == Target)
        {
            Target = null;
        }
    }
}
