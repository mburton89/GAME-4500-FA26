using UnityEngine;
using TMPro;

public class Cannon : MonoBehaviour
{

    public float firerate;
    public float shootVelocity;
    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
    public AudioSource shootSound;
    int ammo;
    bool hasAmmo = true;
    public TextMeshProUGUI ammoText;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ammo = 25;
    }

    // Update is called once per frame
    void Update()
    {
        if (ammo == 0)
        {
            hasAmmo = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (hasAmmo == true)
            {
                Shoot();
            }
        }

    }

    void Shoot()
    {
        //print("Shoot");

        //Instantiate prefab
        GameObject newProjectile = Instantiate (projectilePrefab, projectileSpawnPoint.position, transform.rotation);

        ammo--;
        ammoText.SetText("Ammo: " + ammo);

        //make prefab go  - add force
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * shootVelocity);

        //Make SFX - plunk
        shootSound.Play();

        //destroy prefab after time
        Destroy(newProjectile, 5);


    }
}
