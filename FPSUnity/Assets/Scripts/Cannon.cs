using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float fireRate;
    public float shootVelocity;
    public GameObject projectilePrefab;
    public AudioSource shootSound;
    public Transform projectileSpawnPoint;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        print("Shoot");

        // Step 1: Instantiate/Spawn projectile prefab in projectile spawn point

        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);

        // Step 2: Add forward force to it

        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * shootVelocity);

        // Step 3: Make plunk SFX

        shootSound.Play();

        // Step 4: Despawn projectile after XX seconds

        Destroy(newProjectile, 5);

    }
}
