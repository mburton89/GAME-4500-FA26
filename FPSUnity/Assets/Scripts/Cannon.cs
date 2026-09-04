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
        //how shoot functions
        print("Shoot");

        //Step 1: instantiate/spawn projectile prefab in projectile spawn point
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);

        //Step 2: add forward force to it
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * shootVelocity);

        //Step 3: make plunk SFX
        shootSound.Play();

        //Step 4: destroy projectile after x amount of seconds
        Destroy(newProjectile, 5);
        
    }

}
