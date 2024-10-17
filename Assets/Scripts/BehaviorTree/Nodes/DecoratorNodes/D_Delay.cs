using UnityEngine;

public class D_Delay : DecoratorNode
{
    [SerializeField] private float delay = 2f;
    private float currentTimer = 0f;

    #region Overrides of Node

    protected override void Start()
    {
        base.Start();
        Debug.Log(child.name);
    }
    protected override void OnStart()
    {
        currentTimer = 0f;
    }

    protected override void OnStop()
    {
        currentTimer = 0f;
        Debug.Log("Stop");
    }

    protected override State OnUpdate()
    {
        
        if (currentTimer > delay)
        {
            return child.UpdateNode();
        }
        else
        {
            currentTimer += Tree.CurrentTimer;
            Debug.Log(currentTimer);
        }

        return State.Running;
    }

    #endregion
}
