using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Formations/VFormation")]
public class VFormation : Formation
{
    public override List<Vector3> CalculatePositions(Transform _leaderTransform, int _agentNumber, float _distanceBetweenAgents)
    {
        _distanceBetweenAgents /= 2;
        List<Vector3> positions = new List<Vector3>(_agentNumber);

        Vector3 leader_position = _leaderTransform.position;
        Vector3 leader_forward = _leaderTransform.forward;
        Vector3 leader_right = _leaderTransform.right;

        for (int i = 0; i < _agentNumber; i++)
        {
            float row = Mathf.Floor(i / 2) + 1; 
            float sideMultiplier = (i % 2 == 0) ? 1 : -1; 

            Vector3 new_position = leader_position
                                     + leader_forward * -row * _distanceBetweenAgents
                                     + leader_right * sideMultiplier * row * _distanceBetweenAgents; 

            positions.Add(new_position);
        }

        return positions;
    }
}
