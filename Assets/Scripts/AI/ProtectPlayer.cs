using FSMMono;
using UnityEngine;

public class ProtectPlayer : MonoBehaviour
{
    private FlockAgent agent;
    private AIAgent AIAgent;
    private PlayerAgent playerAgent;

    private Vector3 offset = Vector3.zero;
    public Vector3 Offset { get { return offset; } set { offset = value; } }

    private bool isProtecting = false;
    public bool IsProtecting { get { return isProtecting; } set { isProtecting = value; } }

    private void Start()
    {
        agent = GetComponent<FlockAgent>();
        AIAgent = GetComponent<AIAgent>();
        playerAgent = FindAnyObjectByType<PlayerAgent>();
    }

    public void StopProtectingPlayer()
    {
        agent.ResetFlock();
        offset = Vector3.zero;
        isProtecting = false;
        agent.IsAvailable = true;
    }

    public void ApplyProtecting(Vector3 _offset)
    {
        agent.StopFlocking();
        offset = _offset;
        isProtecting = true;
        agent.IsAvailable = false;
    }

    public void ChangeOffset(Vector3 _offset)
    {
        offset = _offset;
    }
}
