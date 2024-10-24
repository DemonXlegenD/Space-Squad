
public class A_StopProtecting : ActionNode
{
    #region Overrides of Node
    protected override void OnStart() { }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        if (Tree.Data.ContainsData(DataKey.DANGER_ZONE_OFFSETS))
        {
            npc.GetComponent<Guardian>().DeleteOffset();
            return State.Success;
        }

        return State.Failure;
    }

    #endregion
}
