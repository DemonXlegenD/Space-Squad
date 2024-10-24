using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Duration = 2f;
    [SerializeField] private Material M_Ally;
    [SerializeField] private Material M_Enemy;
    private Renderer Renderer;
    private int damage = 0;

    [SerializeField] private LayerMask layerToDealDamage;
    public int Damage { get { return damage; } set { damage = value; } }

    void Start()
    {
        Renderer = GetComponent<Renderer>();
        if (gameObject.layer == LayerMask.NameToLayer("AllyBullet")) Renderer.sharedMaterial = M_Ally;
        else Renderer.sharedMaterial = M_Enemy;
        Destroy(gameObject, Duration);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & layerToDealDamage) != 0)
        {
            IDamageable damagedAgent = collision.gameObject.GetComponentInParent<IDamageable>();
            if (damagedAgent == null)
                damagedAgent = collision.gameObject.GetComponent<IDamageable>();
            damagedAgent?.AddDamage(Damage);
        }
        Destroy(gameObject);
    }
}
