using UnityEngine;

public class CoverFire : MonoBehaviour
{

    [SerializeField] private float minShootDistance = 10f;
    private FlockAgent agent;

    private Vector3 targetToShoot = Vector3.zero;
    public Vector3 TargetToShoot { get { return targetToShoot; } set { targetToShoot = value; } }

    private bool isFiringTarget = false;
    public bool IsFiringTarget { get { return isFiringTarget; } set { isFiringTarget = value; } }

    private void Start()
    {
        agent = GetComponent<FlockAgent>();
    }
    public float DistanceToTarget(Vector3 _target)
    {
        return Vector3.Distance(transform.position, _target);
    }

    public void StopCoverFiring()
    {
        agent.StartFlocking();
        targetToShoot = Vector3.zero;
        isFiringTarget = false;
    }

    public void ApplyCoverFire(Vector3 _target)
    {
        agent.StopFlocking();
        TargetToShoot = _target;
        agent.MoveTo(_target);
    }

    private void Update()
    {
        if (targetToShoot != Vector3.zero)
        {
            if (!isFiringTarget)
            {
                if (DistanceToTarget(targetToShoot) <= minShootDistance)
                {
                    isFiringTarget = true;
                }
            }
            else
            {
                agent.AIAgent.StopMove();
                agent.AIAgent.ShootToPosition(targetToShoot);
            }
        }

    }
}
