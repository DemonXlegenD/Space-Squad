using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Formations/CircleFormation")]
public class CircleFormation : Formation
{
    public override List<Vector3> CalculatePositions(Transform _leaderTransform, int _agentNumber, float _distanceBetweenAgents)
    {
        List<Vector3> positions = new List<Vector3>(_agentNumber);

        int degres = 90;
        float next = 360 / _agentNumber;

        Vector3 leader_position = _leaderTransform.position;
        Vector3 leader_forward = _leaderTransform.forward;
        Quaternion rotation = Quaternion.LookRotation(leader_forward);

        Vector3 center = leader_position - Vector3.forward * _distanceBetweenAgents;
        for (int i = 0; i < _agentNumber; i++)
        {
            Vector3 new_pos = Vector3.zero;
            if (i == 0) new_pos = leader_position;
            else
            {
                new_pos = center + new Vector3(Mathf.Cos(Mathf.Deg2Rad * (degres + next * i)), 0, Mathf.Sin(Mathf.Deg2Rad * (degres + next * i))) * _distanceBetweenAgents;

                new_pos = rotation * (new_pos - leader_position) + leader_position;
            }
            positions.Add(new_pos);
        }

        return positions;
    }
}
