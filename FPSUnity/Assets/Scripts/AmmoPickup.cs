using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoToGive = 10;
    public AmmoSpawner parentSpawner; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>())
        {
            GameManager.Instance.cannon.HandleAmmoPickup(ammoToGive);
            parentSpawner.DelaySpawnAmmo();
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.cannon.HandleAmmoPickup(ammoToGive);
        parentSpawner.DelaySpawnAmmo();
        Destroy(gameObject);
    }
}
