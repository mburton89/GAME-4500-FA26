using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public static AmmoSpawner Instance;
    public GameObject AmmoPrefab;
    public List<Transform> AmmoSpawnPoints;

    public float ammoSpawnDelay;
    public int ammoFillAmount;
    public Cannon cannon;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(AmmoSpawnTimer());
    }

    private IEnumerator AmmoSpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(ammoSpawnDelay);

            SpawnAmmo();
        }
    }

    private void SpawnAmmo()
    {
        for (int i = 0; i < AmmoSpawnPoints.Count; i++)
        {
            if (AmmoSpawnPoints[i].childCount == 0)
            {
                Instantiate(AmmoPrefab, AmmoSpawnPoints[i]);
            }
        }
    }

    public void FillAmmo()
    {
        cannon.ammo += ammoFillAmount;
        if (cannon.ammo > 20)
            cannon.ammo = 20;
        cannon.SetAmmoText();
    }
}
