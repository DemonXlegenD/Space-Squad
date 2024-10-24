using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Formations/SquareFormation")]
public class SquareFormation : Formation
{
    public int rows = 3;              
    public int columns = 3;             

    public override List<Vector3> CalculatePositions(Transform _leaderTransform, int _agentNumber, float _distanceBetweenAgents)
    {
        List<Vector3> positions = new List<Vector3>(_agentNumber);

        Vector3 leader_position = _leaderTransform.position;
        Vector3 leader_forward = _leaderTransform.forward;
        Vector3 leader_right = _leaderTransform.right;

        int totalPositions = (rows * columns) - 1;

        if (_agentNumber > totalPositions)
        {
            Debug.LogWarning("Plus de NPCs que de positions disponibles dans la formation.");
        }

        // Calculer le centre de la formation par rapport au joueur
        Vector3 formationCenterOffset = (columns - 1) * leader_right * _distanceBetweenAgents / 2 +
                                        (rows - 1) * leader_forward * _distanceBetweenAgents / 2;

        int npcIndex = 0;

        // Positionner chaque NPC selon la grille de rang�es et colonnes
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (row == rows / 2 && col == columns / 2)
                {
                    continue;
                }
                if (npcIndex >= _agentNumber) break; 

                Vector3 localPosition = (col * leader_right * _distanceBetweenAgents) + (row * leader_forward * _distanceBetweenAgents) - formationCenterOffset;

                Vector3 new_pos = leader_position + localPosition;

                positions.Add(new_pos);

                npcIndex++;
            }
        }
        return positions;
    }
}
