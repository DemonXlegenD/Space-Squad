using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pool : MonoBehaviour
{
    [SerializeField] public BlackBoard Data;
    [SerializeField] public Text _kda;
    public class Location
    {
        Vector3 position = Vector3.zero;
        public TurretAgent enemy;

        public Location(Vector3 position, TurretAgent enemy)
        {
            this.position = position;
            this.enemy = enemy;
        }

        public void PlaceEnemy(TurretAgent enemy)
        {
            this.enemy = enemy;
            enemy.transform.position = position;
            enemy.Reset();
        }
    }
    public Transform[] positions;

    public TurretAgent prefabTurrentAgent;
    public int numberEnemy = 15;
    public int kill_counter = 0;

    public List<Location> locations = new List<Location>();
    private void Start()
    {
        positions = GetComponentsInChildren<Transform>();
        for (int i = 0; i < positions.Length; i++)
        {
            if (i < numberEnemy)
            {
                locations.Add(new Location(positions[i].position, Instantiate(prefabTurrentAgent, positions[i].position, Quaternion.identity)));
            }
            locations.Add(new Location(positions[i].position, null));
        }

        Data.AddData(DataKey.KDA, kill_counter);
    }


    public void AttributeRandomLocation(TurretAgent _turretAgent)
    {
        List<Location> freeLocations = new List<Location>();
        kill_counter += 1;
        Data.SetData(DataKey.KDA, kill_counter);

        _kda.text = "Kills : " + kill_counter;

        foreach (Location location in locations)
        {
            if (location.enemy == null)
            {
                freeLocations.Add(location);
            }
            if (location.enemy == _turretAgent)
            {
                location.enemy = null;
            }
        }

        freeLocations[Random.Range(0, freeLocations.Count)].PlaceEnemy(_turretAgent);
    }

}
