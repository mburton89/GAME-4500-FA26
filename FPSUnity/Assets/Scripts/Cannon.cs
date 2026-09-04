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
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        print("Shoot");

        //instantiate projectile
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);

        //add forward force
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.up * shootVelocity);

        //make plunk sound effect
        shootSound.Play();

        //despawn projectile
        Destroy(newProjectile, 5);
    }
}
