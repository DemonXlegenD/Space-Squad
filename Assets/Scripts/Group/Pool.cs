using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public class Location{
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

    public List<Location> locations = new List<Location>();
    private void Start()
    {
        positions = GetComponentsInChildren<Transform>();
        for (int i = 0; i < positions.Length; i++)
        {
            if(i < numberEnemy)
            {
                locations.Add(new Location(positions[i].position,  Instantiate(prefabTurrentAgent, positions[i].position, Quaternion.identity)));
            }
            locations.Add(new Location(positions[i].position, null));
        }
    }


    public void AttributeRandomLocation(TurretAgent _turretAgent)
    {
        List<Location> freeLocations = new List<Location>();

        foreach (Location location in locations)
        {
            if (location.enemy == null)
            {
                freeLocations.Add(location);
            }
            if(location.enemy == _turretAgent)
            {
                location.enemy = null;
            }
        }

        freeLocations[Random.Range(0, freeLocations.Count)].PlaceEnemy(_turretAgent);
    }

}
