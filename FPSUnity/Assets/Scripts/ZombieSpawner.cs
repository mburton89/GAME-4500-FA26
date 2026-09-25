using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    int wave;
    public List<GameObject> zombiePrefab;
    public List<Transform> zombieSpawnPoints;

    public TextMeshProUGUI waveText;

    private void Awake()
    {
        Instance = this;
        wave = 1;
    }

    public void SpawnWaveOfZombies()
    {
        print("Spawned a wave of zombies");

        wave++;
        waveText.SetText("Wave: " + wave);

        for (int i = 0; i < wave; i++)
        {
            int rand = Random.Range(0, zombieSpawnPoints.Count);
            int randZombie = Random.Range(0, zombiePrefab.Count);
            Instantiate(zombiePrefab[randZombie], zombieSpawnPoints[rand].position, transform.rotation, transform);
        }
    }

    public void CountCurrentZombies()
    {
        Zombie[] allZombiesInScene = FindObjectsByType<Zombie>(FindObjectsSortMode.None);

        if(allZombiesInScene.Length == 1)
        {
            SpawnWaveOfZombies();
        }
    }
}
