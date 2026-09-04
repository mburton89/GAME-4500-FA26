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
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * shootVelocity);

        float rand = Random.Range(0.9f, 1.1f);

        shootSound.pitch = rand;
        shootSound.Play();
        Destroy(newProjectile, 5);
    }
}
