using UnityEngine;
using System.Collections;
using TMPro;

public class BazookaPowerup : MonoBehaviour
{
    public GameObject bazooka;
    public GameObject cannon;
    public TextMeshProUGUI zookaText;


    private void OnTriggerEnter(Collider other)
    {
        print("Powerup");

        if (other.GetComponent<FPSController>())
        {
            print("Powerup");
            cannon.gameObject.SetActive(false);
            bazooka.gameObject.SetActive(true);
            zookaText.SetText("You Picked Up \"The Fuckin' 'Zooka\"!");
            


            Destroy(gameObject);
            
        }
        
    }

    
}
