using FSMMono;
using UnityEngine;

[RequireComponent(typeof(AIAgent))]
public class FlockAgent : MonoBehaviour
{

    public PlayerAgent playerAgent;
    private AIAgent aiAgent;
    public AIAgent AIAgent { get { return aiAgent; } }
    private Vector3 Position = Vector3.zero;

    private Vector3 offset = Vector3.zero;

    public Vector3 Offset { get { return offset; } set { offset = value; } }

    private bool isFlocking = true;
    public bool IsFlocking { get { return isFlocking; } set { isFlocking = value; } }

    private Vector3 target = Vector3.zero;
    public Vector3 Target { get { return target; } }

    private CoverFire coverFire;
    public CoverFire CoverFire { get { return coverFire; } }

    private AidFire aidFire;
    public AidFire AidFire { get { return aidFire; } }

    private ProtectPlayer protectPlayer;
    public ProtectPlayer ProtectPlayer { get { return protectPlayer; } }

    private Healer healingPlayer;
    public Healer HealingPlayer { get { return healingPlayer; } }

    private bool isAvailable = true;

    public bool IsAvailable { get { return isAvailable; } set { isAvailable = value; } }

    private bool isCurrentlyCoverFiring = false;
    public bool IsCurrentlyCoverFiring { get { return isCurrentlyCoverFiring; } set { isCurrentlyCoverFiring = value; } }
    private bool isCurrentlyHealingPlayer = false;
    public bool IsCurrentlyHealingPlayer { get { return isCurrentlyHealingPlayer; } set { isCurrentlyHealingPlayer = value; } }
    private void Start()
    {
        aiAgent = GetComponent<AIAgent>();
        coverFire = GetComponent<CoverFire>();
        aidFire = GetComponent<AidFire>();
        protectPlayer = GetComponent<ProtectPlayer>();
        healingPlayer = GetComponent<Healer>();
    }

    private void Update() { }

    public void RecalculatePosition()
    {
        Vector3 rotatedOffset = playerAgent.transform.rotation * offset;
        SetTarget(playerAgent.transform.position + rotatedOffset);
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
        RecalculatePosition();
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

    #region Available

    public bool IsProtecting()
    {
        return protectPlayer.IsProtecting;
    }

    public bool IsCoverFiring()
    {
        return coverFire.IsFiringTarget;
    }

    public bool IsHealing()
    {
        return healingPlayer.IsHealing;
    }
    #endregion
}
