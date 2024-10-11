using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAgent : MonoBehaviour, IDamageable
{

    [SerializeField] private LayerMask layers;
    [SerializeField]
    int MaxHP = 100;

    [SerializeField]
    float ShootFrequency = 1f;

    float NextShootDate = 0f;

    Gun Gun;

    bool IsDead = false;
    int CurrentHP;

    GameObject Target = null;

    public void AddDamage(int amount)
    {
        CurrentHP -= amount;
        if (CurrentHP <= 0)
        {
            IsDead = true;
            CurrentHP = 0;

            gameObject.SetActive(false);
        }
    }
    void ShootToPosition(Vector3 pos)
    {
        // look at target position
        transform.LookAt(pos + Vector3.up * transform.position.y);

        // instantiate bullet
        if (Gun)
        {
            Gun.Shoot();
        }
    }
    void Start()
    {
        Gun = GetComponentInChildren<Gun>();

        CurrentHP = MaxHP;
    }

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
