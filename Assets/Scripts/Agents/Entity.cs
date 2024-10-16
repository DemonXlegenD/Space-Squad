using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Entity : MonoBehaviour, IDamageable
{
    protected Gun Gun;
    protected CharacterHealth characterHealth;

    public CharacterHealth CharacterHealth { get { return characterHealth; } }

    protected bool isNeedingHealing = false;

    public bool IsNeedingHealing { get { return isNeedingHealing; } set { isNeedingHealing = value; } }

    public bool IsDead
    {
        get
        {
            if (characterHealth != null) return characterHealth.IsDead();
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
            Vector3 targetLookAt = _pos + Vector3.up * transform.position.y;
            targetLookAt.y = transform.position.y;
            transform.LookAt(targetLookAt);
        }
    }

    public virtual void AddDamage(int _amount)
    {
        characterHealth.TakeDamage(_amount);
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
        characterHealth = GetComponent<CharacterHealth>();
        Gun = GetComponentInChildren<Gun>();
    }


    #endregion


}
