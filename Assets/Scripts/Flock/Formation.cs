using System.Collections.Generic;
using UnityEngine;

public abstract class Formation : ScriptableObject
{
    public abstract List<Vector3> CalculatePositions(Transform _leaderTransform, int _agentNumber, float _distanceBetweenAgents);
}
