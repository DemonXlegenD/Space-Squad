using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Formations/CircleProtectionFormation")]
public class CircleProtectionFormation : Formation
{
    public override List<Vector3> CalculatePositions(Transform _leaderTransform, int _agentNumber, float _distanceBetweenAgents)
    {
        List<Vector3> positions = new List<Vector3>(_agentNumber);

        Vector3 leader_position = _leaderTransform.position;
        Vector3 leader_forward = _leaderTransform.forward;
        Vector3 leader_right = _leaderTransform.right;

        float angleStep = 360.0f / _agentNumber;

        Vector3 center = leader_position;
        for (int i = 0; i < _agentNumber; i++)
        {
            float angle = i * angleStep;

            float angleRad = angle * Mathf.Deg2Rad;

            Vector3 offset = ((leader_forward * Mathf.Cos(angleRad)) + (leader_right * Mathf.Sin(angleRad))) * _distanceBetweenAgents;
            Vector3 new_pos = leader_position + offset;
            positions.Add(new_pos);
        }

        return positions;
    }
}
