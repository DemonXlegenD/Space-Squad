using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BlackBoard", order = 1)]

public class BlackBoard : ScriptableObject
{
    public Dictionary<DataKey, object> Data = new Dictionary<DataKey, object>();

    public void AddData(DataKey x, object y) 
    {
        Data.Add(x, y);
        Debug.Log(Data.Count);
    }

    public object GetData(DataKey x) 
    {
        return Data[x];
    }

    public void SetData(DataKey x, object y) 
    {
        Data[x] = y;
    }
}

public enum DataKey{
    PLAYER,

}