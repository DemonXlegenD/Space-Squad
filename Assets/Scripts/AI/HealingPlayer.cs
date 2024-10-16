using FSMMono;
using UnityEngine;

public class HealingPlayer : MonoBehaviour
{
    [SerializeField] private float timerHealing = 1f;
    private float currentTimer = 0f;
    private FlockAgent agent;
    private AIAgent AIAgent;
    private PlayerAgent playerAgent;

    private Vector3 offset = Vector3.zero;
    public Vector3 Offset { get { return offset; } set { offset = value; } }

    private bool isHealing = false;
    public bool IsHealing { get { return isHealing; } set { isHealing = value; } }

    private void Start()
    {
        agent = GetComponent<FlockAgent>();
        AIAgent = GetComponent<AIAgent>();
        playerAgent = FindAnyObjectByType<PlayerAgent>();
    }

    public void StopHealingPlayer()
    {
        agent.ResetFlock();
        currentTimer = 0f;
        offset = Vector3.zero;
        isHealing = false;
        agent.IsAvailable = true;
    }

    public void ApplyHealingPlayer()
    {
        agent.StopFlocking();
        isHealing = true;
        agent.IsAvailable = false;
    }

    private void Update()
    {
        if (isHealing)
        {
            if (Vector3.Distance(playerAgent.transform.position, transform.position) <= 2f)
            {
                agent.MoveTo(playerAgent.transform.position);
                currentTimer = 0f;
            }
            else
            {
                currentTimer += Time.deltaTime;
                if (currentTimer > timerHealing) { 
                    playerAgent.CharacterHealth.Healing(10f);
                    currentTimer = 0f;
                }
            }

            if (playerAgent.CharacterHealth.IsMaxHealth())
            {
                StopHealingPlayer();
            }
        }
    }
}
