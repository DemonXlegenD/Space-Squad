using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Flock : MonoBehaviour
{
    private List<FlockAgent> flockAgents = new List<FlockAgent>();
    public List<FlockAgent> FlockAgents { get { return flockAgents; } }

    [SerializeField] private FlockAgent flockAgentPrefab;
    [SerializeField] private List<FlockAgent> roleAgentPrefab = new List<FlockAgent>();
    private Formation formation;
    [SerializeField] private Formation VFormation;
    [SerializeField] private Formation SquareFormation;
    [SerializeField] private Formation CircleFormation;


    [SerializeField, Range(3, 15)] private int startingCount = 3;   


    [SerializeField] private Vector3 leaderPosition = Vector3.zero;
    [SerializeField] private PlayerAgent leader;
    private Vector3 oldForwardLeader = Vector3.zero;
    [SerializeField]
    private float distanceBetweenAgent = 5f;

    private ProtectGroup protectGroup;

    public ProtectGroup ProtectGroup { get { return protectGroup; } }

    private HealingPlayerGroup healingGroup;

    public HealingPlayerGroup HealingGroup { get { return healingGroup; } }

    public BlackBoard BlackBoard;

    public void ApplyVFormation()
    {
        formation = VFormation;
        Recalculate();
    }

    public void ApplySquareFormation()
    {
        formation = SquareFormation;
        Recalculate();
    }

    public void ApplyCircleFormation()
    {
        formation = CircleFormation;
        Recalculate();
    }


    private void Start()
    {
        formation = SquareFormation;
        protectGroup = GetComponent<ProtectGroup>();
        healingGroup = GetComponent<HealingPlayerGroup>();
        List<Vector3> positions = formation.CalculatePositions(leader.transform, startingCount, distanceBetweenAgent);

        oldForwardLeader = leader.transform.forward;

        for (int i = 0; i < startingCount; i++)
        {
            Vector3 position = positions[i];

            SpawnNPC(position, i);
        }
    }

    private void SpawnNPC(Vector3 _position, int _index)
    {

        FlockAgent new_agent = Instantiate(
            roleAgentPrefab[_index % roleAgentPrefab.Count],
            _position,
            Quaternion.Euler(Vector3.forward),
            null
            );

        new_agent.playerAgent = leader;
        new_agent.SetTarget(_position);
        new_agent.name = "Agent" + _index;
        new_agent.Offset = _position - leader.transform.position;

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
            agent.Offset = positions[i] - leader.transform.position;
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

    public List<FlockAgent> GetCloserAgents(Vector3 _target, int _percent = 50, bool healer = false)
    {
        Dictionary<FlockAgent, float> distanceToNPCMap = new Dictionary<FlockAgent, float>(FlockAgents.Count);

        foreach (FlockAgent flock_agent in FlockAgents)
        {
           if (flock_agent.IsAvailable) 
           {
                if (flock_agent.GetComponent<Healer>() != null && healer) 
                {
                    distanceToNPCMap.Add(flock_agent, flock_agent.DistanceToTarget(_target));
                } else if (!healer) {
                    distanceToNPCMap.Add(flock_agent, flock_agent.DistanceToTarget(_target));
                }
           } 
        }

        int countToRetrieve = Mathf.CeilToInt(distanceToNPCMap.Count * _percent / 100);

        return distanceToNPCMap
            .OrderBy(kvp => kvp.Value)
            .Take(countToRetrieve)
            .Select(pair => pair.Key)
            .ToList();
    }

    private void Update()
    {
        /*if (oldForwardLeader != leader.transform.forward)
        {
            oldForwardLeader = leader.transform.forward;
            Recalculate();
        }*/
    }
}
