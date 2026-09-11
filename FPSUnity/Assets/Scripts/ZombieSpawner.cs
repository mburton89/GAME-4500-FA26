using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    int wave;
    public GameObject zombiePrefab;
    public List<Transform> zombieSpawnPoints;

    public TextMeshProUGUI waveText;

    private void Awake()
    {
        Instance = this;
        SpawnWaveOfZombies();
    }

    public void SpawnWaveOfZombies()
    {
        print("Wave");
        
        wave++;
        waveText.SetText("Wave: " + wave);
        
        for (int i = 0; i < wave; i++)
        {
            int rand = UnityEngine.Random.Range(0, zombieSpawnPoints.Count);
            Instantiate(zombiePrefab, zombieSpawnPoints[rand].position, transform.rotation, transform);
        }
    }

    public void CountCurrentZombies()
    {
        Zombie[] allZombiesInScene = FindObjectsOfType<Zombie>();

        if(allZombiesInScene.Length == 1)
        { SpawnWaveOfZombies(); }
    }
}
