using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float fireRate;
    public float shootVelocity;
    public GameObject projectilePrefab;
    public AudioSource shootSound;
    public Transform projectileSpawnPoint;

    public int ammo = 20;

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
        if (ammo > 0)
        {
            ammo--;
            UpdateAmmoUI();
        }
        else return;

            //OUR SHOOT CODE
            print("Shoot");

        //Step 1: Instantiate/Spawn projectile prefab in projectile spawn point
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);

        //Step 2: Add forward force to it
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.up * shootVelocity);

        //Step 3: Make plunk SFX 
        shootSound.Play();

        //Step 4: Despawn projectile after X seconds
        Destroy(newProjectile, 5);
    }

    public void UpdateAmmoUI()
    {
        GameManager.instance.ammoText.SetText("Ammo: " + ammo);
    }
}
