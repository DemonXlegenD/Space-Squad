using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    float BulletPower = 1000f;
    [SerializeField]
    GameObject BulletPrefab;

    public LayerMask layers;
    [SerializeField, Range(5,25)] private float range = 10f;
    public float Range { get { return range; } } 

    [SerializeField, Range(1, 100)] private int maxBullets = 10;
    private int currentBullets = 10;
    [SerializeField] private float timerFire = 0.2f;
    private float currentTimerFire = 0f;

    [SerializeField] private float timerReloading = 2f;
    private float currentTimerReloading = 0f;

    private bool hasShoot = false;
    public void Shoot()
    {
        if (HasBullets() && !hasShoot)
        {
            Ray ray = new Ray(transform.position, transform.up);
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit, range, layers))
            {
                if (BulletPrefab)
                {
                    GameObject bullet = Instantiate<GameObject>(BulletPrefab, transform.position + transform.up * 0.5f, Quaternion.identity);
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.AddForce(transform.up * BulletPower);
                    currentBullets--;
                    hasShoot = true;
                }
            }
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
