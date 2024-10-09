using FSMMono;
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
    public CoverFire CoverFire { get { return coverFire; } set { coverFire = value; } }

    private void Start()
    {
        aiAgent = GetComponent<AIAgent>();
        CoverFire = GetComponent<CoverFire>();
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
}
