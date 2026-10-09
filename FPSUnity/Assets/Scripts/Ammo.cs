using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int ammoToGive;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>())
        {
            collision.gameObject.GetComponent<Canon>().TakeAmmo(ammoToGive);
        }
    }

}
