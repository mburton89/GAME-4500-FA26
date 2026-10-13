using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public static PowerupSpawner Instance;


    public GameObject PowerupPrefab;

    public List<Transform> powerupSpawnPoints;

    private int delay = 1;

    

    private void Awake() //Happens before the first frame
    {
        Instance = this;
        SpawnPowerups();

        if (delay == 0)
        {
            Invoke("SpawnPowerups", 30);
        }
    }

    public void SpawnPowerups()
    {
        
        //GameObject chosenPrefab = (Random.value > 0.5f) ? zombiePrefab : zombiePrefab2;

        //for (int i = 0; i < wave; i++)
        //{
            int rand = Random.Range(0, powerupSpawnPoints.Count);
            //Instantiate(chosenPrefab, zombieSpawnPoints[rand].position, transform.rotation, transform);
        //}
        Instantiate(PowerupPrefab, powerupSpawnPoints[rand].position, transform.rotation, transform);

        delay = 0;


    }

    //public void CountCurrentZombies()
    //{
       //Zombie[] allZombiesInScene = FindObjectsByType<Zombie>(FindObjectsSortMode.None);

        //if (allZombiesInScene.Length == 1)
        //{
            //SpawnWaveOfZombies();
        //}
    //}
}
