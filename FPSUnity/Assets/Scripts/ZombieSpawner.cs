using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;
    
    private int wave;
    public List<GameObject> ZombieTypes;
    public List<Transform> ZombieSpawnPoints;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI highestWaveText;

    private void Awake()
    {
        Instance = this;
        wave = 1;
        highestWaveText.SetText("Best: " + PlayerPrefs.GetInt("BestWave"));
    }

    public void SpawnWaveOfZombies()
    {
        //print("Spawn Wave");

        wave++;
        waveText.SetText("Wave: " + wave);

        if (wave > PlayerPrefs.GetInt("BestWave"))
        {
            //Yay new high score!
            PlayerPrefs.SetInt("BestWave", wave);
            highestWaveText.SetText("Best: " + PlayerPrefs.GetInt("BestWave"));
        }

        for (int i = 0; i < wave; i++)
        {
            int rand = Random.Range(0, ZombieSpawnPoints.Count);
            int randZomb = Random.Range(0, ZombieTypes.Count);
            Instantiate(ZombieTypes[randZomb], ZombieSpawnPoints[rand].position, transform.rotation, transform);
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
