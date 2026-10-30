using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject ammoPrefab;
    public List<Transform> ammoSpawnPoints;
    public float respawnRate = 30f;

    private void Start()
    {
        SpawnAmmo();
    }

    public void DelaySpawnAmmo()
    {
        StartCoroutine(DelaySpawnCo());
    }

    public void SpawnAmmo()
    {
        int rand = Random.Range(0, ammoSpawnPoints.Count);
        GameObject newAmmoPickup = Instantiate(ammoPrefab, ammoSpawnPoints[rand].position, transform.rotation, transform);

        newAmmoPickup.GetComponent<Ammo>().parentSpawner = this;
        print("hello");
    }
    
    private IEnumerator DelaySpawnCo()
    {
        yield return new WaitForSeconds(respawnRate);
        SpawnAmmo();
    }
}
