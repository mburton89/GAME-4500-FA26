using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    int wave;
    public List<Transform> zombieSpawnPoints;

    public List<GameObject> zombiePrefabs; //RANDOM ZOMBIES

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI highestWaveText;

    private void Awake()
    {
        Instance = this;
        wave = 1;
        highestWaveText.SetText("Best: " + PlayerPrefs.GetInt("HighestWave"));
    }

    public void SpawnWaveOfZombies()
    {
        print("SpawnWaveOfZombies");

        wave++;
        waveText.SetText("Wave: " + wave);

        if (wave > PlayerPrefs.GetInt("HighestWave"))
        {
            //Yay new high score!
            PlayerPrefs.SetInt("HighestWave", wave);
            highestWaveText.SetText("Best: " + PlayerPrefs.GetInt("HighestWave"));
        }

        for (int i = 0; i < wave; i++)
        {
            int rand = Random.Range(0, zombieSpawnPoints.Count);
            int randZombie = Random.Range(0, zombiePrefabs.Count);
            Instantiate(zombiePrefabs[randZombie], zombieSpawnPoints[rand].position, transform.rotation, transform);
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
