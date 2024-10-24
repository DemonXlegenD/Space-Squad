public class A_ReformationNode : ActionNode
{
    public bool shouldReset = false;

    #region Overrides of Node
    protected override void OnStart() { }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        if (shouldReset)
        {
            npc.GetComponent<FlockAgent>().ResetFlock();

            return State.Success;
        }
        return State.Failure;
    }

    #endregion
}
