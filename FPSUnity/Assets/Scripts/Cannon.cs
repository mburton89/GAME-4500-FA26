using TMPro;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public static Cannon Instance;

    public float fireRate;
    public float projSpeed;
    public GameObject projectilePrefab;
    public AudioSource shootSound;
    public Transform projectileSpawnpoint;
    public TextMeshProUGUI ammoText;

    int ammo;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        Instance = this;
        ammo = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        print("Shot");

        ammo--;
        ammoText.SetText("Ammo: " + ammo);

        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnpoint.position, transform.rotation);

        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnpoint.forward * projSpeed);

        shootSound.Play();

        Destroy(newProjectile, 5);
    }

    public void AmmoCount()
    {

    }
}
