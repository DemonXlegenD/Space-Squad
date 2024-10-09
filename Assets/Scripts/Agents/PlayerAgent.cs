using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAgent : MonoBehaviour, IDamageable
{
    [SerializeField]
    int MaxHP = 100;
    
    private Gun Gun;

    [SerializeField]
    GameObject TargetCursorPrefab = null;
    [SerializeField]
    GameObject NPCTargetCursorPrefab = null;

    [SerializeField]
    Slider HPSlider = null;

    Rigidbody rb;
    GameObject TargetCursor = null;
    GameObject NPCTargetCursor = null;

    bool IsDead = false;
    int CurrentHP;

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
    public void AimAtPosition(Vector3 pos)
    {
        GetTargetCursor().transform.position = pos;
        if (Vector3.Distance(transform.position, pos) > 2.5f)
            transform.LookAt(pos + Vector3.up * transform.position.y);
    }
    public void ShootToPosition(Vector3 pos)
    {
        // fire
        if (Gun)
        {
            Gun.Shoot();
        }
    }
    public void NPCShootToPosition(Vector3 pos)
    {
        GetNPCTargetCursor().transform.position = pos;

    }
    public void AddDamage(int amount)
    {
        CurrentHP -= amount;
        if (CurrentHP <= 0)
        {
            IsDead = true;
            CurrentHP = 0;
        }
        if (HPSlider != null)
        {
            HPSlider.value = CurrentHP;
        }
    }
    public void MoveToward(Vector3 velocity)
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    #region MonoBehaviour Methods
    void Start()
    {
        CurrentHP = MaxHP;
        Gun = GetComponentInChildren<Gun>();
        rb = GetComponent<Rigidbody>();

        if (HPSlider != null)
        {
            HPSlider.maxValue = MaxHP;
            HPSlider.value = CurrentHP;
        }
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
