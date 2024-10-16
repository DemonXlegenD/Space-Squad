using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeMapping
{
    public Dictionary<DataKey, Type> typeMapping = new Dictionary<DataKey, Type>();

    public Type GetTypeFromEnum(DataKey valueType)
    {
        if (typeMapping.TryGetValue(valueType, out Type type))
        {
            return type;
        }
        else
        {
            Debug.LogError($"Type non trouvé pour {valueType.ToString()}");
            return null;
        }
    }

    public void AddValueType(DataKey valueType, Type type)
    {
        if (!typeMapping.ContainsKey(valueType))
        {
            typeMapping.Add(valueType, type);
            Debug.Log($"Ajout de {valueType} avec le type {type}");
        }
        else
        {
            Debug.LogWarning($"Le ValueType {valueType} est déjà associé au type {typeMapping[valueType]} et ne sera pas ajouté à nouveau.");
        }
    }
}
