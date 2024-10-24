using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BlackBoard", order = 1)]

public class BlackBoard : ScriptableObject
{
    public TypeMapping TypeMapping = new TypeMapping();
    public Dictionary<DataKey, object> Data = new Dictionary<DataKey, object>();

    public void AddData<T>(DataKey key, T y) 
    {
        TypeMapping.AddValueType(key, typeof(T)); 
        Data.Add(key, y);
    }

    public object GetData(DataKey key) 
    {
        if (Data.TryGetValue(key, out object value))
        {
            if (TypeMapping.typeMapping.TryGetValue(key, out Type expectedType))
            {
                if (value.GetType() == expectedType)
                {
                    return value;
                }
                else
                {
                    Debug.LogError($"La valeur pour la cl� '{key}' est de type {value.GetType()}, mais {expectedType} �tait attendu.");
                    return null;
                }
            }
            else
            {
                Debug.LogError($"Type non trouv� pour la cl� '{key}' dans le mapping.");
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public T GetValue<T>(DataKey key)
    {
        // V�rifier si le key existe dans Data
        if (Data.TryGetValue(key, out object value))
        {
            // V�rifier que le type attendu correspond � celui dans le typeMapping
            if (TypeMapping.typeMapping.TryGetValue(key, out Type expectedType))
            {
                // V�rifier que T correspond bien au type attendu
                if (typeof(T) == expectedType)
                {
                    // Tenter de caster en T
                    if (value is T castValue)
                    {
                        return castValue;
                    }
                    else
                    {
                        Debug.LogError($"La valeur pour la cl� '{key}' ne peut pas �tre cast�e en {typeof(T)}.");
                        return default;
                    }
                }
                else
                {
                    Debug.LogError($"Le type attendu pour la cl� '{key}' est {expectedType}, mais {typeof(T)} a �t� fourni.");
                    return default;
                }
            }
            else
            {
                Debug.LogError($"Type non trouv� pour la cl� '{key}' dans le mapping.");
                return default;
            }
        }
        else
        {
            return default;
        }
    }

    public bool ContainsData(DataKey key)
    {
        return Data.ContainsKey(key);
    }

    public void SetData(DataKey x, object y) 
    {
        Data[x] = y;
    }
}
public enum DataKey{
    PLAYER,
    DANGER_ZONE_OFFSETS,
    TARGET_HEALER,
    TARGET_PROTECT,
    TARGET_COVER,
    TARGET_FIRING,
    KDA,
}