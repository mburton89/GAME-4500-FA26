using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Cannon : MonoBehaviour
{
    public float fireRate;
    public float shootVelocity;
    public GameObject projectilePrefab;
    public AudioSource shootSound;
    public Transform projectileSpawnPoint;

    public TextMeshProUGUI ammoText;

    public int currentAmmo = 20;
    public int maxAmmo = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateAmmoUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0)
            {
                Shoot();
            }
            else
            {
                Debug.Log("No Ammo!");
            }
        }
    }


    void Shoot()
    {
            //Our Shoot Code
            print("shoot");

            //Step 1: Instantiate/spawn a projectile prefab in projectile spawn point
            GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);

            //Step 2: Add forward force to it
            newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * shootVelocity);

            //Step 3: Make plunk SFX
            shootSound.Play();

        currentAmmo--;
        UpdateAmmoUI();
        //Step 4: Despawn projectile after x seconds
        Destroy(newProjectile, 5);
        
    }

    void UpdateAmmoUI()
    {
        ammoText.SetText("Ammo: " + currentAmmo);
    }

    public void Reload(int amount)
    {
        currentAmmo = Mathf.Min(currentAmmo + amount, maxAmmo);
        UpdateAmmoUI();
    }
}
