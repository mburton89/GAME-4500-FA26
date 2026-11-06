using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int ammoFillAmount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>())
        {
            PickUpAmmo();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSController>())
        {
            PickUpAmmo();
        }
    }

    private void PickUpAmmo()
    {
        GameManager.Instance.FillAmmo(ammoFillAmount);
        
        //Individual spawn timers
        Transform spawnPoint = transform.parent;
        AmmoSpawner.Instance.RespawnAmmo(spawnPoint);

        Destroy(gameObject);
    }
}
