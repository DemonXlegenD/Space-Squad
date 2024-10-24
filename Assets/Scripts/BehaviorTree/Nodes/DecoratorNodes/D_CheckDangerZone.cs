public class D_CheckDangerZone : DecoratorNode
{
    #region Overrides of Node

    protected override void OnStart()
    {
    }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        if (Tree.Data.ContainsData(DataKey.DANGER_ZONE_OFFSETS))
        {
            if (Tree.Data.GetValue<OffsetsCheck>(DataKey.DANGER_ZONE_OFFSETS).IsOneOffsetFree())
            {
                return child.UpdateNode();
            }
        }
        return State.Failure;
    }

    #endregion

}
