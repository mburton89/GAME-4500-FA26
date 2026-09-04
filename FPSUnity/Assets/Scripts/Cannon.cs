using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float fireRate;
    public float projSpeed;
    public GameObject projectilePrefab;
    public AudioSource shootSound;
    public Transform projectileSpawnpoint;


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
        print("Shot");

        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnpoint.position, transform.rotation);

        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnpoint.forward * projSpeed);

        shootSound.Play();

        Destroy(newProjectile, 5);
    }
}
