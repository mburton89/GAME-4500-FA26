using UnityEngine;

public class canon : MonoBehaviour
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
        print("Shoot");

        // Step 1: instantiate /Spawn projectile prefab
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);

        // Step 2: add forward force to it
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * shootVelocity);

        //Step 3: add sound effect
        shootSound.Play();

        //Step 4: despawn projectiles
        Destroy(newProjectile, 5);
    }
}
