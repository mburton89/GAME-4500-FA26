
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [Header("Ammo Settings")]
    public int ammoAmount = 10;

    [Header("Rotation")]
    public float rotationSpeed = 90f;

    [Header("Floating")]
    public float floatSpeed = 2f;
    public float floatHeight = 0.25f;

    private Vector3 startPosition;

    void Start()
    {
        // Remember starting position
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate the ammo pack
        transform.Rotate(
            Vector3.up * rotationSpeed * Time.deltaTime
        );

        // Make ammo pack float up and down
        float newY = Mathf.Sin(Time.time * floatSpeed)
                     * floatHeight;

        transform.position = startPosition
                             + Vector3.up * newY;
    }

    void OnTriggerEnter(Collider other)
    {
        // Find the player
        FPSController player =
            other.GetComponentInParent<FPSController>();

        if (player != null)
        {
            // Find the player's cannon
            Cannon cannon =
                player.GetComponentInChildren<Cannon>();

            if (cannon != null)
            {
                // Give ammunition
                cannon.AddAmmo(ammoAmount);

                // Remove pickup
                Destroy(gameObject);

                Debug.Log("Ammo Pickup Collected!");
            }
        }
    }
}
