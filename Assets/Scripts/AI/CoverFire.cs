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

    public void NPCShootToTarget(Vector3 target_)
    {
        if (target_ != Vector3.zero)
        {
            AIAgent.ShootToPosition(target_);
        }
    }
}
