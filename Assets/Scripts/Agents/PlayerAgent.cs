using UnityEngine;

public class PlayerAgent : Entity
{

    [SerializeField]
    GameObject TargetCursorPrefab = null;

    Rigidbody rb;
    GameObject TargetCursor = null;
    Flock Flock = null;
    

    private GameObject GetTargetCursor()
    {
        if (TargetCursor == null)
            TargetCursor = Instantiate(TargetCursorPrefab);
        return TargetCursor;
    }

    public override void AddDamage(int _amount)
    {
        base.AddDamage(_amount);
        if (CharacterHealth.IsLowHealth())
        {
            Debug.Log("LowHealth");
            Flock.HealingGroup.ApplyHealingPlayer(transform.position);
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

    #region MonoBehaviour Methods
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        Flock = FindAnyObjectByType<Flock>();

        Data.AddData(DataKey.PLAYER, this);
    }
    void Update()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 3);
    }

    #endregion
}
