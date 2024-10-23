using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Bullet : MonoBehaviour
{
    public float Duration = 2f;
    [SerializeField] private Material M_Ally;
    [SerializeField] private Material M_Enemy;
    private Renderer Renderer;

    void Start()
    {
        Renderer = GetComponent<Renderer>();
        if(gameObject.layer == LayerMask.NameToLayer("AllyBullet")) Renderer.sharedMaterial = M_Ally;
        else Renderer.sharedMaterial = M_Enemy;
        Destroy(gameObject, Duration);
    }
    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damagedAgent = collision.gameObject.GetComponentInParent<IDamageable>();
        if (damagedAgent == null)
            damagedAgent = collision.gameObject.GetComponent<IDamageable>();
        damagedAgent?.AddDamage(10);

        Destroy(gameObject);
    }
}
