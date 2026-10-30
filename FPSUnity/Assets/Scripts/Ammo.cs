using JetBrains.Annotations;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int ammoToGive = 10;
    public AmmoSpawner parentSpawner;

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.GetComponent<FPSController>())
        {
            GameManager.Instance.cannon.HandleAmmoPickup(ammoToGive);
            parentSpawner.DelaySpawnAmmo();
            Destroy(gameObject);
        }
    }
}
