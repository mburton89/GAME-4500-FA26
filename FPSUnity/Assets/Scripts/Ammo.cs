using UnityEngine;

public class Ammo : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>())
        {
            AmmoSpawner.Instance.FillAmmo();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSController>())
        {
            AmmoSpawner.Instance.FillAmmo();
            Destroy(gameObject);
        }
    }
}
