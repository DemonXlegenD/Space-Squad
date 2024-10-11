using FSMMono;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectPlayer : MonoBehaviour
{
    private FlockAgent agent;
    private AIAgent AIAgent;

    private Vector3 targetToShoot = Vector3.zero;
    public Vector3 TargetToShoot { get { return targetToShoot; } set { targetToShoot = value; } }

    private bool isProtecting = false;
    public bool IsProtecting { get { return isProtecting; } set { isProtecting = value; } }

    private void Start()
    {
        agent = GetComponent<FlockAgent>();
        AIAgent = GetComponent<AIAgent>();
    }

    public void StopProtecting()
    {
        agent.StartFlocking();
        targetToShoot = Vector3.zero;
        isProtecting = false;
    }

    public void ApplyProtecting(Vector3 _target)
    {
        agent.StopFlocking();
        TargetToShoot = _target;
        agent.MoveTo(_target);
    }

    private void Update()
    {
        
    }
}
