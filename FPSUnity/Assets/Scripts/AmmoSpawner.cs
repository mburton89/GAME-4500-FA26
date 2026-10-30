using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

public class AmmoSpawner : MonoBehaviour
{
    public static AmmoSpawner Instance;

    public List<GameObject> ammoPickupPrefabs;
    public List<Transform> ammoSpawnPoints;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnAmmoPickup()
    {
        Debug.Log("SpawnAmmo");

        int rand = Random.Range(0, ammoSpawnPoints.Count);
        int randAmmo = Random.Range(0, ammoPickupPrefabs.Count);
        Instantiate(ammoPickupPrefabs[randAmmo], ammoSpawnPoints[rand].position, transform.rotation, transform);
        
    }
}
