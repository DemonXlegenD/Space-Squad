using FSMMono;
using UnityEngine;

[RequireComponent(typeof(AIAgent))]
public class FlockAgent : MonoBehaviour
{
    private AIAgent Agent;
    private Vector3 Position = Vector3.zero;
    private Vector3 offset = Vector3.zero;

    public Vector3 Offset {  get { return offset; } set { offset = value; } }

    private void Start()
    {
        Agent = GetComponent<AIAgent>();
    }

    public void SetTarget(Vector3 Target)
    {
        Agent.MoveTo(Target);
    }

    public void Move()
    {
        //Movement.ChangeBehaviour(Behaviour.SEEK);
    }
}
