using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    int wave;

    public GameObject zombiePrefab;

    public List<Transform> zombieSpawnPoints;

    public TextMeshProUGUI waveText;

    private void Awake() //Happens before the first frame
    {
        Instance = this;
        wave = 1;
    }

    public void SpawnWaveOfZombies()
    {
        //print("Spawn Zombies");

        wave++;
        waveText.SetText("Wave: " + wave);

        for (int i = 0; i < wave; i++)
        {
            int rand = Random.Range(0, zombieSpawnPoints.Count);
            Instantiate(zombiePrefab, zombieSpawnPoints[rand].position, transform.rotation, transform);
        }

        
    }

    public void CountCurrentZombies()
    {
        Zombie[] allZombiesInScene = FindObjectsByType<Zombie>(FindObjectsSortMode.None);

        if (allZombiesInScene.Length == 1)
        {
            SpawnWaveOfZombies();
        }
    }

}
