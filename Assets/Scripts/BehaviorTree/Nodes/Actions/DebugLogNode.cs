public class DebugLogNode : ActionNode
{
    public string message;

    #region Overrides of Node
    protected override void OnStart() { }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        return State.Success;
    }

    #endregion
}