using UnityEngine;

public class D_Delay : DecoratorNode
{
    [SerializeField] private float delay = 2f;
    [SerializeField] public bool RESET = false;
    private float currentTimer = 0f;

    #region Overrides of Node

    protected override void Start()
    {
        base.Start();
    }
    protected override void OnStart()
    {
        currentTimer = 0f;
    }

    protected override void OnStop()
    {
        currentTimer = 0f;
    }

    protected override State OnUpdate()
    {        
        if (RESET) 
        {
            currentTimer = 0f;
            RESET = false;
        }
        
        if (currentTimer > delay)
        {
            return child.UpdateNode();
        }
        else
        {
            currentTimer += Tree.CurrentTimer;
        }

        return State.Running;
    }

    #endregion
}
