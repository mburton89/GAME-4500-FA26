using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class AmmoSpawner : MonoBehaviour
{
    public GameObject ammoPickupPrefab;
    public Transform spawnPoint;
    public float respawnRate = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        GameObject newAmmoPickup = Instantiate(ammoPickupPrefab, spawnPoint.position, transform.rotation, transform);
        newAmmoPickup.GetComponent<AmmoPickup>().parentSpawner = this;
    }
    // Update is called once per frame

    private IEnumerator DelaySpawnCo()
    {
        yield return new WaitForSeconds(respawnRate);
    }
  
}
