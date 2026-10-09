using System.Threading.Tasks;
using UnityEngine;

public class GetAmmo : MonoBehaviour
{
    private async Task OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>())
        {
            GameManager.instance.ammo += 10;
            GameManager.instance.ammoText.SetText("Ammo: " + GameManager.instance.ammo);
            gameObject.SetActive(false);
            await Task.Delay(30000);
            gameObject.SetActive(true);
        }
    }

    private async Task OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSController>())
        {
            GameManager.instance.ammo += 10;
            GameManager.instance.ammoText.SetText("Ammo: " + GameManager.instance.ammo);
            gameObject.SetActive(false);
            await Task.Delay(30000);
            gameObject.SetActive(true);
        }
    }
}
