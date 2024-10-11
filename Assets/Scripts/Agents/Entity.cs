using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Entity : MonoBehaviour, IDamageable
{
    protected Gun Gun;
    protected CharacterHealth CharacterHealth;
    public bool IsDead
    {
        get
        {
            if (CharacterHealth != null) return CharacterHealth.IsDead();
            return true;
        }
    }

    public virtual void ShootToPosition(Vector3 _pos)
    {
        // fire
        if (Gun)
        {
            AimAtPosition(_pos);
            if (IsInRangeAndNotTooClose(_pos)) Gun.Shoot();
        }
    }

    public virtual void AimAtPosition(Vector3 _pos)
    {
        if (IsInRangeAndNotTooClose(_pos))
        {
            transform.LookAt(_pos + Vector3.up * transform.position.y);
        }
    }

    public virtual void AddDamage(int _amount)
    {
        CharacterHealth.TakeDamage(_amount);
    }

    public bool IsTooClose(Vector3 _position)
    {
        return Vector3.Distance(transform.position, _position) > Gun.MinRange;
    }

    public bool IsInRange(Vector3 _position)
    {
        return Vector3.Distance(transform.position, _position) < Gun.MaxRange;
    }

    public bool IsInRangeAndNotTooClose(Vector3 _position)
    {
        float distance = Vector3.Distance(transform.position, _position);
        return distance < Gun.MaxRange && distance > Gun.MinRange;
    }
    public float DistanceToTarget(Vector3 _target)
    {
        return Vector3.Distance(transform.position, _target);
    }


    #region MonoBehaviour Methods
    protected virtual void Start()
    {
        CharacterHealth = GetComponent<CharacterHealth>();
        Gun = GetComponentInChildren<Gun>();
    }


    #endregion


}
