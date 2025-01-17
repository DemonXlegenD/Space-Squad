using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAgent : Entity
{
    [SerializeField] GameObject TargetCursorPrefab = null;
    [SerializeField] private float HoldAidFiring = 0.5f;

    Rigidbody rb;
    GameObject TargetCursor = null;
    GameObject AidFiringTargetCursor = null;
    Flock Flock = null;

    private float currentTimer_ = 0f;

    #region MonoBehaviour Methods
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        Flock = FindAnyObjectByType<Flock>();

        Data.AddData(DataKey.PLAYER, this);
        AidFiringTargetCursor = Instantiate(TargetCursorPrefab);
        AidFiringTargetCursor.SetActive(false);
        Data.AddData(DataKey.TARGET_FIRING, AidFiringTargetCursor);
    }
    void Update()
    {
        if (AidFiringTargetCursor != null)
        {
            if (AidFiringTargetCursor.activeSelf)
            {
                currentTimer_ += Time.deltaTime;
                if (currentTimer_ > HoldAidFiring)
                {
                    AidFiringTargetCursor.SetActive(false);
                    currentTimer_ = 0f;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 3);
    }

    #endregion


    private GameObject GetTargetCursor()
    {
        if (TargetCursor == null)
            TargetCursor = Instantiate(TargetCursorPrefab);
        return TargetCursor;
    }
    public override void ShootToPosition(Vector3 _pos)
    {
        if (Gun)
        {
            AimAtPosition(_pos);
            if (IsInRangeAndNotTooClose(_pos))
            {
                Gun.Shoot();
                AidFiring(_pos);
            }
        }
    }

    public void AidFiring(Vector3 _pos)
    {
        currentTimer_ = 0f;
        AidFiringTargetCursor.transform.position = _pos;
        AidFiringTargetCursor.SetActive(true);
    }

    public override void AddDamage(int _amount)
    {
        base.AddDamage(_amount);
        if (!CharacterHealth.IsMaxHealth())
        {
            Flock.HealingGroup.ApplyHealingPlayer(transform.position);
        }
        if (characterHealth.IsDead())
        {
            SceneManager.LoadScene(0);
        }
    }

    public override void AimAtPosition(Vector3 _pos)
    {
        GameObject targetCursor = GetTargetCursor();
        PlayerTarget playerTarget = targetCursor.GetComponent<PlayerTarget>();
        targetCursor.transform.position = _pos;

        if (IsInRangeAndNotTooClose(_pos))
        {
            playerTarget.SetCloseTarget();
            Vector3 targetLookAt = _pos + Vector3.up * transform.position.y;
            targetLookAt.y = transform.position.y;
            transform.LookAt(targetLookAt);
        }
        else playerTarget.SetFarTarget();
    }

    public void MoveToward(Vector3 _velocity)
    {
        rb.MovePosition(rb.position + _velocity * Time.deltaTime);
    }

}
