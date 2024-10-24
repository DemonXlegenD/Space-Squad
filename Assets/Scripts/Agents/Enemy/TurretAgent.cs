using UnityEngine;

public class TurretAgent : Entity
{
    [SerializeField] private bool isMachineGun = false;
    [SerializeField] private LayerMask layers;

    [SerializeField]
    float ShootFrequency = 1f;

    float NextShootDate = 0f;

    GameObject Target = null;
    public override void AddDamage(int _amount)
    {
        characterHealth.TakeDamage(_amount);
        if (characterHealth.IsDead())
        {
            FindAnyObjectByType<Pool>().AttributeRandomLocation(this);
        }
    }

    void Update()
    {
        DetectNearbyObjects();

        if (Target && Time.time >= NextShootDate && isMachineGun)
        {

            NextShootDate = Time.time + ShootFrequency;
            ShootToPosition(Target.transform.position);
        }
    }

    void DetectNearbyObjects()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, Gun.MaxRange, layers);

        foreach (Collider collider in colliders)
        {
            float distance = Vector3.Distance(transform.position, collider.transform.position);

            if (distance >= Gun.MinRange)
            {
                Target = collider.gameObject;
                return;
            }
        }
        Target = null;
    }
}
