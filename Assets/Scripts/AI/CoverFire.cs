using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverFire : MonoBehaviour
{
    private bool isFiringTarget = false;
    public bool IsFiringTarget {  get { return isFiringTarget; } set { isFiringTarget = value; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float DistanceToTarget(Vector3 _target)
    {
        return Vector3.Distance(transform.position, _target);
    }
}
