using FSMMono;
using UnityEngine;

public class CoverFire : MonoBehaviour
{
    private FlockAgent agent;
    private AIAgent AIAgent;

    private Vector3 targetToShoot = Vector3.zero;
    public Vector3 TargetToShoot { get { return targetToShoot; } set { targetToShoot = value; } }

    private bool isFiringTarget = false;
    public bool IsFiringTarget { get { return isFiringTarget; } set { isFiringTarget = value; } }

    private void Start()
    {
        agent = GetComponent<FlockAgent>();
        AIAgent = GetComponent<AIAgent>();
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
                if (AIAgent.IsInRange(targetToShoot))
                {
                    isFiringTarget = true;
                    AIAgent.StopMove();
                }
            }
            else
            {
                AIAgent.ShootToPosition(targetToShoot);
            }
        }

    }
}
