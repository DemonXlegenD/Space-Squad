using UnityEngine;

public class PlayerAgent : Entity
{

    [SerializeField]
    GameObject TargetCursorPrefab = null;
    [SerializeField]
    GameObject NPCTargetCursorPrefab = null;

    Rigidbody rb;
    GameObject TargetCursor = null;
    GameObject NPCTargetCursor = null;

    private GameObject GetTargetCursor()
    {
        if (TargetCursor == null)
            TargetCursor = Instantiate(TargetCursorPrefab);
        return TargetCursor;
    }
    private GameObject GetNPCTargetCursor()
    {
        if (NPCTargetCursor == null)
        {
            NPCTargetCursor = Instantiate(NPCTargetCursorPrefab);
        }
        return NPCTargetCursor;
    }
    public void AimAtPosition(Vector3 _pos)
    {
        GameObject targetCursor = GetTargetCursor();
        PlayerTarget playerTarget = targetCursor.GetComponent<PlayerTarget>();
        targetCursor.transform.position = _pos;

        if (IsInRangeAndNotTooClose(_pos, 2.5f)) 
        { 
            playerTarget.SetCloseTarget();  
            transform.LookAt(_pos + Vector3.up * transform.position.y);
        }
        else playerTarget.SetFarTarget();
    }
    public void NPCShootToPosition(Vector3 _pos)
    {
        GetNPCTargetCursor().transform.position = _pos;

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
