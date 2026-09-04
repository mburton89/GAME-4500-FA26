using UnityEngine;

public class Cannon : MonoBehaviour
{

    public float fireRate;
    public float shootVelocity;
    public GameObject projectilePrefab;
    public AudioSource shootSound;
    public Transform projectileSpawnPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // OUR SHOOT CODE
        print("shoot");

        //step 1: instantiate/spawn projectile prefab in projectile spawn point
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);

        //step 2: add forward force to it
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * shootVelocity);
        
        //step 3: make plunk SFX
        shootSound.Play();

        //step 4: Despawn projectile after x seconds
        Destroy(newProjectile, 5);
    }

}
