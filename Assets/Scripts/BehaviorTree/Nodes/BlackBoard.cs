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
        Debug.Log(Data.Count);
    }

    public object GetData(DataKey key) 
    {
       // Vérifier si la clé existe dans Data
        if (Data.TryGetValue(key, out object value))
        {
            // Vérifier que le type attendu correspond à celui dans le typeMapping
            if (TypeMapping.typeMapping.TryGetValue(key, out Type expectedType))
            {
                // Vérifier que la valeur correspond bien au type attendu
                if (value.GetType() == expectedType)
                {
                    return value;
                }
                else
                {
                    Debug.LogError($"La valeur pour la clé '{key}' est de type {value.GetType()}, mais {expectedType} était attendu.");
                    return null;
                }
            }
            else
            {
                Debug.LogError($"Type non trouvé pour la clé '{key}' dans le mapping.");
                return null;
            }
        }
        else
        {
            Debug.LogError($"Clé '{key}' non trouvée dans les données.");
            return null;
        }
    }

    public T GetValue<T>(DataKey key)
    {
        // Vérifier si le key existe dans Data
        if (Data.TryGetValue(key, out object value))
        {
            // Vérifier que le type attendu correspond à celui dans le typeMapping
            if (TypeMapping.typeMapping.TryGetValue(key, out Type expectedType))
            {
                // Vérifier que T correspond bien au type attendu
                if (typeof(T) == expectedType)
                {
                    // Tenter de caster en T
                    if (value is T castValue)
                    {
                        return castValue;
                    }
                    else
                    {
                        Debug.LogError($"La valeur pour la clé '{key}' ne peut pas être castée en {typeof(T)}.");
                        return default;
                    }
                }
                else
                {
                    Debug.LogError($"Le type attendu pour la clé '{key}' est {expectedType}, mais {typeof(T)} a été fourni.");
                    return default;
                }
            }
            else
            {
                Debug.LogError($"Type non trouvé pour la clé '{key}' dans le mapping.");
                return default;
            }
        }
        else
        {
            Debug.LogError($"Clé '{key}' non trouvée dans les données.");
            return default;
        }
    }



    public void SetData(DataKey x, object y) 
    {
        Data[x] = y;
    }
}

public enum DataKey{
    PLAYER,

}