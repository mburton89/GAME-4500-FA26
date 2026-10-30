using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class AmmoPack : MonoBehaviour
{
    
    public int ammoToGive = 10;
    public AmmoSpawner parentSpawner;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>())
        {
            GameManager.instance.cannon.HandleAmmoPickup(ammoToGive);
            parentSpawner.DelaySpawnAmmo();
            Destroy(gameObject);
        }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSController>())
        {
            GameManager.instance.cannon.HandleAmmoPickup(ammoToGive);
            parentSpawner.DelaySpawnAmmo();
            Destroy(gameObject);
        }
    }






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
