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
            if (IsInRangeAndNotTooClose(_pos, 2.5f)) Gun.Shoot();
        }
    }
    public virtual void AddDamage(int _amount)
    {
        CharacterHealth.TakeDamage(_amount);
    }

    public bool IsTooClose(Vector3 _position, float _closeRange)
    {
        return Vector3.Distance(transform.position, _position) > _closeRange;
    }

    public bool IsInRange(Vector3 _position)
    {
        return Vector3.Distance(transform.position, _position) < Gun.Range;
    }

    public bool IsInRangeAndNotTooClose(Vector3 _position,float _closeRange)
    {
        float distance = Vector3.Distance(transform.position, _position);
        return distance < Gun.Range && distance > _closeRange;
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
