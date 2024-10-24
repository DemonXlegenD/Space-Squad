using UnityEngine;

public class D_InputFire : DecoratorNode
{
    #region Overrides of Node
    protected override void OnStart()
    {
    }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        if (Tree.Data.ContainsData(DataKey.TARGET_FIRING))
        {
            if (Tree.Data.GetValue<GameObject>(DataKey.TARGET_FIRING).activeSelf)
                return child.UpdateNode();
        }
        return State.Success;
    }

    #endregion
}
