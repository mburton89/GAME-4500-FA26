using UnityEngine;

public class BazookaPowerup : MonoBehaviour
{
    public GameObject bazooka;
    public GameObject cannon;
    

    private void OnTriggerEnter(Collider other)
    {
        print("Powerup");

        if (other.GetComponent<FPSController>())
        {
            print("Powerup");
            cannon.gameObject.SetActive(false);
            bazooka.gameObject.SetActive(true);
            
            Destroy(gameObject);
            
        }
    }

    void ResetGun()
    {
        // Code to run after 5 seconds
        print("Switch guns");

        cannon.gameObject.SetActive(true);
        bazooka.gameObject.SetActive(false);
    }
}
