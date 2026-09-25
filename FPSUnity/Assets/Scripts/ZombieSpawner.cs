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

    private void Awake()
    {
        Instance = this;
        wave = 1;
    }

    public void SpawnWaveOfZombies()
    {
        //print("Spawn Wave");

        wave++;
        waveText.SetText("Wave: " + wave);

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
