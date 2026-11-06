using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    int wave;
    public List<GameObject> zombiePreFab;
    public List<Transform> zombieSpawnPoints;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI highestWaveText;

    private void Awake()
    {
        Instance = this;
        wave = 1;
        highestWaveText.SetText("Best: " + PlayerPrefs.GetInt("HighestWave"));
    }
    public void spawnWaveOfZombies()
    {
        print("SpawnWaveOfZombies");

        wave++;
        waveText.SetText("Wave: " +  wave);

        if(wave > PlayerPrefs.GetInt("HighestWave"))
        {
            //yay new high score
            PlayerPrefs.SetInt("HighestWave", wave);
            highestWaveText.SetText("Best: " + PlayerPrefs.GetInt("HighestWave"));

        }

        for (int i = 0; i < wave; i++)
        {

            int rand = Random.Range(0, zombieSpawnPoints.Count);
            Instantiate(zombiePreFab[rand], zombieSpawnPoints[rand].position, transform.rotation, transform);
            
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
