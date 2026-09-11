using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    int wave;
    public GameObject zombiePreFab;
    public List<Transform> zombieSpawnPoints;

    public TextMeshProUGUI waveText;

    private void Awake()
    {
        Instance = this;
        wave = 1;
    }
    public void spawnWaveOfZombies()
    {
        print("SpawnWaveOfZombies");

        wave++;
        waveText.SetText("Wave: " +  wave);

        for (int i = 0; i < wave; i++)
        {

            int rand = Random.Range(0, zombieSpawnPoints.Count);
            Instantiate(zombiePreFab, zombieSpawnPoints[rand].position, transform.rotation, transform);
            
        }

    }
    public void countCurrentZombies()
    {
        Zombie[] allZombiesInScene = FindObjectsOfType<Zombie>();

        if(allZombiesInScene.Length == 1 )
        {
            spawnWaveOfZombies();
        }
    }
}
