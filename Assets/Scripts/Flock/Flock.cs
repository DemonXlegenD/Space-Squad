using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Flock : MonoBehaviour
{
    private List<FlockAgent> flockAgents = new List<FlockAgent>();
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
        Debug.Log("Forward " + oldForwardLeader);
        for (int i = 0; i < startingCount; i++)
        {
            Debug.Log(positions[i]);

            FlockAgent new_agent = Instantiate(
                flockAgentPrefab,
                positions[i],
                Quaternion.Euler(Vector3.forward),
                transform
                );
         
            new_agent.Offset = positions[i] - leaderPosition;
            new_agent.name = "Agent" + i;

            flockAgents.Add(new_agent);
        }

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
        }

    }

    public void Reformation()
    {
        leaderPosition = leader.transform.position - new Vector3(0,0.5f,0);
    
        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent agent = flockAgents[i];
            agent.SetTarget(leaderPosition + agent.Offset);
        }
    }

    public List<FlockAgent> FlockAgents { get { return flockAgents; } }

    public void SetTarget(Vector3 target)
    {
        foreach(FlockAgent agent in flockAgents)
        {
            agent.SetTarget(target + agent.Offset);
        }
    }

    private void Update()
    {
        if(oldForwardLeader != leader.transform.forward)
        {
            oldForwardLeader = leader.transform.forward;
            Recalculate();
        }
    }
}
