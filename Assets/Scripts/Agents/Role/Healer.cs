using FSMMono;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Role
{
    [SerializeField] private Color color = Color.cyan;

    [SerializeField] private float timerHealing = 1f;
    [SerializeField] private float healingDistance = 2f;
    private float currentTimer = 0f;
    private FlockAgent agent;
    private AIAgent AIAgent;
    private PlayerAgent playerAgent;

    private Vector3 offset = Vector3.zero;
    public Vector3 Offset { get { return offset; } set { offset = value; } }

    private bool isHealing = false;
    public bool IsHealing { get { return isHealing; } set { isHealing = value; } }

    protected override void Start()
    {
        base.Start();
        SetColorToMaterial(color);
        agent = GetComponent<FlockAgent>();
        AIAgent = GetComponent<AIAgent>();
        playerAgent = FindAnyObjectByType<PlayerAgent>();
    }

    public void StopHealingPlayer()
    {
        currentTimer = 0f;
        offset = Vector3.zero;
        isHealing = false;
    }

    public void ApplyHealingPlayer()
    {
        isHealing = true;
    }

    public void HealPlayer()
    {
        if (isHealing)
        {
            playerAgent.CharacterHealth.Healing(10f);
        }
    }

    private void Update()
    {
        if (isHealing)
        {
            if (Vector3.Distance(playerAgent.transform.position, agent.transform.position) > healingDistance)
            {
                agent.MoveTo(playerAgent.transform.position);
                currentTimer = 0f;
                Debug.Log("Not Good Distance");
            }
            else
            {
                AIAgent.StopMove();
                currentTimer += Time.deltaTime;
                if (currentTimer > timerHealing)
                {
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
