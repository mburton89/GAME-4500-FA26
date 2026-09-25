using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    int wave;

    public GameObject zombiePrefab1;
    public GameObject zombiePrefab2;

    public List<Transform> zombieSpawnPoints;

    public TextMeshProUGUI waveText;

    private void Awake()
    {
        Instance = this;
        wave = 1;
    }

    public void SpawnWaveOfZombies()
    {
        print("SpawnWaveOfZombies");

        wave++;
        waveText.SetText("Wave: " + wave);

        for (int i = 0; i < wave; i++)
        {
            int rand = Random.Range(0, zombieSpawnPoints.Count);

            GameObject zombieToSpawn;

            if (Random.Range(0, 2) == 0)
            {
                zombieToSpawn = zombiePrefab1;
            }
            else
            {
                zombieToSpawn = zombiePrefab2;
            }

             Instantiate(
                zombieToSpawn,
                zombieSpawnPoints[rand].position,
                transform.rotation,
                transform
            );
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