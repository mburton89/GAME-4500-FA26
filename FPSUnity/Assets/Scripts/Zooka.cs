using UnityEngine;

public class Zooka : MonoBehaviour
{

    public float firerate;
    public float shootVelocity;
    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
    public AudioSource shootSound;
    private float canShoot = 1;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canShoot == 1)
            {
                Shoot();
                
              
                

            }
            
        }

    }

    void Shoot()
    {
        //print("Shoot");
        canShoot = 0;
        //Instantiate prefab
        GameObject newProjectile = Instantiate (projectilePrefab, projectileSpawnPoint.position, transform.rotation);

        //make prefab go  - add force
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * shootVelocity);

        //Make SFX - plunk
        shootSound.Play();

        //destroy prefab after time
        Destroy(newProjectile, 2);

        Invoke("MyDelayedFunction", 2);

    }

    void MyDelayedFunction()
    {
        // Code to run after 5 seconds
        
        canShoot = 1;
    }
}
