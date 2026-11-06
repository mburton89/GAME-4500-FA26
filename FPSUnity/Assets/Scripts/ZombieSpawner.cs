using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{

    public static ZombieSpawner Instance;

    int wave;
    public List<Transform> zombieSpawnPoints;
    public List<GameObject> zombiePrefabs;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI highestWaveText;

    private void Awake()
    {
        Instance = this;
        wave = 1;
        highestWaveText.text = "Highest Wave: " + PlayerPrefs.GetInt("HighestWave");
    }

    private void Start()
    {
        SpawnZombie();
    }

    public GameObject RandomlySelectZombie()
    {
        int rand = Random.Range(0, zombiePrefabs.Count);
        GameObject zombie = zombiePrefabs[rand];

        return zombie;
    }

    public void SpawnZombie()
    {
        int rand = Random.Range(0, zombieSpawnPoints.Count);
        GameObject zombie = RandomlySelectZombie();
        Instantiate(zombie, zombieSpawnPoints[rand].position, transform.rotation, transform);
    }

    public void SpawnWaveOfZombies()
    {
        print("Spawn waves");

        wave++;
        waveText.SetText("Wave: " + wave);

        if (wave > PlayerPrefs.GetInt("HighestWave"))
        {
            // New high score
            PlayerPrefs.SetInt("HighestWave", wave);
            highestWaveText.text = "Highest Wave: " + PlayerPrefs.GetInt("HighestWave");
        }

        for (int i = 0; i < wave; ++i)
        {
            SpawnZombie();
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
