using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoToGive = 10;
    public AmmoSpawner parentSpawner;
    public AudioClip soundEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>())
        {
            GameManager.Instance.cannon.HandleAmmoPickup(ammoToGive);
            parentSpawner.DelaySpawnAmmo();
            SoundManager.instance.PlayPowerupSound();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSController>())
        {
            GameManager.Instance.cannon.HandleAmmoPickup(ammoToGive);
            parentSpawner.DelaySpawnAmmo();
            SoundManager.instance.PlayPowerupSound();
            Destroy(gameObject);
        }
    }
}
