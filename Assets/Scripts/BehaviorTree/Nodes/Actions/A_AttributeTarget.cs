public class A_AttributeTarget : ActionNode
{
    #region Overrides of Node
    protected override void OnStart() { }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        if (Tree.Data.ContainsData(DataKey.DANGER_ZONE_OFFSETS))
        {
            npc.GetComponent<Guardian>().AttributeOffset(Tree.Data.GetValue<OffsetsCheck>(DataKey.DANGER_ZONE_OFFSETS).GetFreeOffset());
            return State.Success;
        }

        return State.Failure;
    }

    #endregion
}
