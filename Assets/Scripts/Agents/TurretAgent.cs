using FSMMono;
using System;
using System.Collections;
using System.Collections.Generic;
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
        if (characterHealth.IsDead()) { 
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
        // Cr�e une sph�re de d�tection autour de l'objet (transform.position) avec un rayon de 10 m
        Collider[] colliders = Physics.OverlapSphere(transform.position, Gun.MaxRange, layers);

        // Parcours tous les colliders d�tect�s
        foreach (Collider collider in colliders)
        {
            // Calcule la distance entre l'objet d�tect� et l'objet qui porte ce script
            float distance = Vector3.Distance(transform.position, collider.transform.position);

            // V�rifie si la distance est sup�rieure � la distance minimale
            if (distance >= Gun.MinRange)
            {
                Target = collider.gameObject;
                return;
            }
        }
        Target = null;
    }
}
