using UnityEngine;

public class Canon : MonoBehaviour
{
    public float fireRate;
    public float shootVelocity;
    public GameObject projectileprefab;
    public AudioSource shootSound;
    public Transform projectileSpawnPoint;
    // Transform in 3D games tells you how 3D objects exist in your Game World

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
        print("shoot");
        //weeeeeeeeeeeeeeeeeeeeeeee

        //I like bread

        //step 1: Instantiate/Spawn Projectile Prefab in projectile spawnpoint :P

        GameObject newProjectile = Instantiate(projectileprefab, projectileSpawnPoint.position, transform.rotation);

        //Instatiate can catch past data to use later on

        //Step 2: Add forward force to it

        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * shootVelocity);

        //Step 3: Make a SFX

        shootSound.Play();

        //Step 4: Despawn projectile after X seconds

        Destroy(newProjectile, 5);
    }
}
