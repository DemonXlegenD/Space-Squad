using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    private List<FlockAgent> flockAgents = new List<FlockAgent>();
    public List<FlockAgent> FlockAgents { get { return flockAgents; } }

    [SerializeField] private FlockAgent flockAgentPrefab;
    [SerializeField] private Formation formation;

    [SerializeField, Range(3, 15)] private int startingCount = 3;
    [SerializeField] private Vector3 leaderPosition = Vector3.zero;
    [SerializeField] private PlayerAgent leader;
    private Vector3 oldForwardLeader = Vector3.zero;
    [SerializeField]
    private float distanceBetweenAgent = 5f;


    private void Start()
    {
        List<Vector3> positions = formation.CalculatePositions(leader.transform, startingCount, distanceBetweenAgent);

        oldForwardLeader = leader.transform.forward;

        for (int i = 0; i < startingCount; i++)
        {
            Vector3 position = positions[i];

            SpawnNPC(position, i);
        }

    }

    private void SpawnNPC(Vector3 position, int index)
    {

        FlockAgent new_agent = Instantiate(
            flockAgentPrefab,
            position,
            Quaternion.Euler(Vector3.forward),
            transform
            );

        new_agent.SetTarget(position);
        new_agent.name = "Agent" + index;

        flockAgents.Add(new_agent);
    }

    private Vector3 GetCenterPosition(List<Vector3> _positions)
    {
        float average_x = 0;
        float average_z = 0;

        foreach (Vector3 position in _positions)
        {
            average_x += position.x;
            average_z += position.z;
        }

        return new Vector3(average_x, 0, average_z) / _positions.Count;
    }

    public void Recalculate()
    {
        leaderPosition = leader.transform.position;
        List<Vector3> positions = formation.CalculatePositions(leader.transform, startingCount, distanceBetweenAgent);
        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent agent = flockAgents[i];
            agent.SetTarget(positions[i]);
            agent.Move();
        }
    }

    public void Reformation()
    {
        leaderPosition = leader.transform.position - new Vector3(0, 0.5f, 0);

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent agent = flockAgents[i];
            agent.ResetFlock();
        }
    }

    private void Update()
    {
        if (oldForwardLeader != leader.transform.forward)
        {
            oldForwardLeader = leader.transform.forward;
            Recalculate();
        }
    }
}
