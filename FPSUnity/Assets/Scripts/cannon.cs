using UnityEngine;
using TMPro;


public class Cannon : MonoBehaviour
{
    public float fireRate;
    public float shootVelocity;
    public GameObject projectilePreFab;
    public AudioSource shootSound;
    public Transform projectileSpawnPoint;

    public int startingAmmo;
    public int currentAmmo;
    public TextMeshProUGUI ammoText;

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
        //our shoot code
        print("Shoot");

        //step 1: instantiate/spawn projectile preFab in projectile spawn point
        GameObject newProjectile = Instantiate(projectilePreFab, projectileSpawnPoint.position, transform.rotation);

        //step 2: add forward force to it
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * shootVelocity);

        //step 3: make plunk SFX
        shootSound.Play();

        //step 4: destroy after X amount of seconds
        Destroy(newProjectile, 5);
    }

    public void UpdateAmmoUI()
    {
        string ammoString = "Ammo: " + currentAmmo;
        ammoText.SetText(ammoString);
    }

    public void HandleAmmoPickup(int numberOfAmmo)
    {
        currentAmmo += numberOfAmmo;
        UpdateAmmoUI();
    }
}
