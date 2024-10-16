using FSMMono;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIAgent))]
public class FlockAgent : MonoBehaviour
{
    private AIAgent aiAgent;
    public AIAgent AIAgent { get { return aiAgent; } }
    private Vector3 Position = Vector3.zero; 

    private bool isFlocking = true;
    public bool IsFlocking { get { return isFlocking; } set { isFlocking = value; } }

    private Vector3 target = Vector3.zero;
    public Vector3 Target {  get { return target; }}

    private CoverFire coverFire;
    public CoverFire CoverFire { get { return coverFire; } }

    private AidFire aidFire;
    public AidFire AidFire { get { return aidFire; } }

    private ProtectPlayer protectPlayer;
    public ProtectPlayer ProtectPlayer { get { return protectPlayer; } }

    private HealingPlayer healingPlayer;
    public HealingPlayer HealingPlayer { get { return healingPlayer; } }

    private bool isAvailable = true;   

    public bool IsAvailable { get { return isAvailable; } set { isAvailable = value; } }

    private void Start()
    {
        aiAgent = GetComponent<AIAgent>();
        coverFire = GetComponent<CoverFire>();
        aidFire = GetComponent<AidFire>();
        protectPlayer = GetComponent<ProtectPlayer>();
        healingPlayer = GetComponent<HealingPlayer>();
    }

    public void SetTarget(Vector3 _target)
    {
        target = _target;
    }

    public void StartFlocking()
    {
        isFlocking = true;
    }

    public void StopFlocking()
    {
        isFlocking = false;
    }

    public void ResetFlock()
    {
        StartFlocking();
        Move();
    }
    public void Move()
    {
        if (isFlocking)
        {
            aiAgent.MoveTo(Target);
        }
    }

    public void MoveTo(Vector3 _target)
    {
        aiAgent.MoveTo(_target);
    }

    public float DistanceToTarget(Vector3 _target)
    {
        return Vector3.Distance(transform.position, _target);
    }

}
