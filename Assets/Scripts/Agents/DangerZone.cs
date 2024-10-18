using FSMMono;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetsCheck
{
    private List<OffsetCheck> offsets = new List<OffsetCheck>();

    public void AddOffsetCheck(Vector3 offset)
    {
        offsets.Add(new OffsetCheck(offset, false));
    }

    public bool IsOneOffsetFree()
    {
        foreach (OffsetCheck offset_check in offsets)
        {
            if (!offset_check.isCheck)
            {
                return true;
            }
        }
        return false;
    }

    public OffsetCheck GetFreeOffset()
    {
        foreach(OffsetCheck offset_check in offsets)
        {
            if(!offset_check.isCheck) { 
                offset_check.isCheck = true;
                return offset_check; 
            }
        }
        return null;
    }
}

public class OffsetCheck
{
    public Vector3 offset;
    public bool isCheck;
    private AIAgent aIAgent;

    public OffsetCheck(Vector3 _offset, bool _isCheck)
    {
        this.offset = _offset;
        this.isCheck = _isCheck;
    }

    public void AttributeAIAgent(AIAgent _AIAgent)
    {
        aIAgent = _AIAgent;
    }

    public AIAgent GetAIAgent()
    {
        return aIAgent;
    }
}

public class DangerZone : MonoBehaviour
{
    private Collider DangerCollider;
    private Flock flock;
    private BlackBoard blackBoard;
    private OffsetsCheck OffsetsCheck = new OffsetsCheck();



    [SerializeField] private LayerMask BulletMask;
    // Start is called before the first frame update
    void Start()
    {
        DangerCollider = GetComponent<Collider>();
        flock = FindAnyObjectByType<Flock>();

        blackBoard = GetComponentInParent<PlayerAgent>().Data;
        blackBoard.AddData<OffsetsCheck>(DataKey.DANGER_ZONE_OFFSETS, OffsetsCheck);
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other != null && ((1 << _other.gameObject.layer) & BulletMask) != 0)
        {
            OffsetsCheck.AddOffsetCheck(GetProtectionPos(_other.transform.position));
        }
    }

    private Vector3 GetProtectionPos(Vector3 _target)
    {
        return _target - transform.position;
    }
}
