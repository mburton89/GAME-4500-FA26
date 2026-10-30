
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Shooting")]
    public float fireRate = 0.25f;
    public float shootVelocity = 1000f;
    public GameObject projectilePrefab;
    public AudioSource shootSound;
    public Transform projectileSpawnPoint;

    [Header("Ammunition")]
    public int startingAmmo = 30;
    public int maxAmmo = 60;
    public int currentAmmo;

    [Header("UI")]
    public AmmoUI ammoUI;

    private float nextFireTime = 0f;

    void Start()
    {
        // Set starting ammunition
        currentAmmo = startingAmmo;

        // Update ammo counter
        UpdateAmmoUI();
    }

    void Update()
    {
        // Shoot when left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Check if player has ammunition
        if (currentAmmo <= 0)
        {
            Debug.Log("Out of Ammo!");
            return;
        }

        // Check firing cooldown
        if (Time.time < nextFireTime)
        {
            return;
        }

        // Set next allowed firing time
        nextFireTime = Time.time + fireRate;

        // Spawn projectile at the spawn point
        GameObject newProjectile = Instantiate(
            projectilePrefab,
            projectileSpawnPoint.position,
            projectileSpawnPoint.rotation
        );

        // Add forward force to projectile
        newProjectile.GetComponent<Rigidbody>().AddForce(
            projectileSpawnPoint.forward * shootVelocity
        );

        // Play shooting sound
        if (shootSound != null)
        {
            shootSound.Play();
        }

        // Remove one bullet
        currentAmmo--;

        // Update ammo counter
        UpdateAmmoUI();

        // Destroy projectile after 5 seconds
        Destroy(newProjectile, 5f);

        Debug.Log("Ammo remaining: " + currentAmmo);
    }

    // Add ammunition when player collects a pickup
    public void AddAmmo(int amount)
    {
        currentAmmo += amount;

        // Prevent ammo from exceeding maximum
        currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo);

        // Update ammo counter
        UpdateAmmoUI();

        Debug.Log("Ammo collected! Current ammo: " + currentAmmo);
    }

    // Update ammunition display
    void UpdateAmmoUI()
    {
        if (ammoUI != null)
        {
            ammoUI.UpdateAmmo(currentAmmo, maxAmmo);
        }
    }
}
