using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public static AmmoSpawner Instance;
    public GameObject AmmoPrefab;
    public List<Transform> AmmoSpawnPoints;

    public float ammoSpawnDelay;
    public int ammoFillAmount;
    public Cannon cannon;
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        // Use for a glocal 10 second Ammo Respawn Timer
        //StartCoroutine(AmmoSpawnTimer());
        
        //Individual spawn timers
        SpawnAmmo();
    }

    //Individual spawn timers
    private void SpawnAmmo()
    {
        foreach (Transform spawnPoint in AmmoSpawnPoints)
        {
            if (spawnPoint.childCount == 0)
            {
                Instantiate(AmmoPrefab, spawnPoint);
            }
        }
    }

    //Individual spawn timers
    public void RespawnAmmo(Transform spawnPoint)
    {
        StartCoroutine(AmmoRespawnTimer(spawnPoint));
    }

    //Individual spawn timers
    private IEnumerator AmmoRespawnTimer(Transform spawnPoint)
    {
        yield return new WaitForSeconds(ammoSpawnDelay);

        if (spawnPoint != null && spawnPoint.childCount == 0)
        {
            Instantiate(AmmoPrefab, spawnPoint);
        }
    }

    /*
     * Use these for a global 10 seconds Ammo Spawn Timer
    private IEnumerator AmmoSpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(ammoSpawnDelay);
            Debug.Log("Ammo Spawn Atempt");
            SpawnAmmo();
        }
    }

    private void SpawnAmmo()
    {
        for (int i = 0; i < AmmoSpawnPoints.Count; i++)
        {
            if (AmmoSpawnPoints[i].childCount == 0)
            {
                Instantiate(AmmoPrefab, AmmoSpawnPoints[i]);
            }
        }
    }
    */
}
