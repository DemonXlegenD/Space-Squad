using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    float BulletPower = 1000f;
    [SerializeField]
    GameObject BulletPrefab;
    [SerializeField]
    GameObject DropAmmoPrefab;

    public LayerMask layers;
    [SerializeField, Range(10f, 25f)] private float maxRange = 10f;
    public float MaxRange { get { return maxRange; } }

    [SerializeField, Range(0f, 5f)] private float minRange = 2.5f;
    public float MinRange { get { return minRange; } }

    [SerializeField, Range(1, 100)] private int maxBullets = 10;
    private int currentBullets = 10;
    [SerializeField] private float timerFire = 0.2f;
    private float currentTimerFire = 0f;

    [SerializeField] private float timerReloading = 2f;
    private float currentTimerReloading = 0f;

    private bool hasShoot = false;

    private LayerMask bulletLayerMask;
    public void Shoot()
    {
        if (HasBullets() && !hasShoot)
        {
            Ray ray = new Ray(transform.position, transform.up);
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit, MaxRange, layers))
            {
                if (BulletPrefab && DropAmmoPrefab)
                {
                    GameObject bullet = Instantiate<GameObject>(BulletPrefab, transform.position + (transform.up * 0.5f), Quaternion.LookRotation(transform.forward, transform.up));
                    GameObject drop_ammo = Instantiate<GameObject>(DropAmmoPrefab, transform.position + (transform.up * 0.5f) + (transform.right * 0.2f), Quaternion.LookRotation(transform.forward, transform.up));
                    bullet.layer = bulletLayerMask; 
                    drop_ammo.layer = bulletLayerMask;
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.AddForce(transform.up * BulletPower);
                    currentBullets--;
                    hasShoot = true;
                }
            }
        }
    }

    private void Start()
    {
        if ((1 << gameObject.layer) == LayerMask.GetMask("Allies") || (1 << gameObject.layer) == LayerMask.GetMask("Player"))
        {
            bulletLayerMask = LayerMask.NameToLayer("AllyBullet");
        }
        else if ((1 << gameObject.layer) == LayerMask.GetMask("Enemies"))
        {
            bulletLayerMask = LayerMask.NameToLayer("EnemyBullet");
        }

    }

    private void Update()
    {
        if (!HasBullets())
        {
            Reloading();
        }
        if (hasShoot)
        {
            WaitAfterShoot();
        }
    }

    public void WaitAfterShoot()
    {
        if (currentTimerFire > timerFire)
        {
            hasShoot = false;
            currentTimerFire = 0f;
        }
        else
        {
            currentTimerFire += Time.deltaTime;
        }

    }

    public void Reloading()
    {
        if (currentTimerReloading > timerReloading) Reload();
        else currentTimerReloading += Time.deltaTime;
    }

    public void Reload()
    {
        currentBullets = maxBullets;
        currentTimerReloading = 0f;
    }

    public bool HasBullets()
    {
        return currentBullets > 0;
    }
}
