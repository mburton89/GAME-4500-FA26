using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int ammoToGive;

    private void OnTriggerEnter(Collider Collider)
    {
        if(Collider.gameObject.GetComponent<FPSController>())
        {
            Collider.gameObject.GetComponentInChildren<Canon>().TakeAmmo(ammoToGive);
            AmmoSpawner.Instance.SpawnAmmoPickup();
            Destroy(gameObject);
        }

    }


}
