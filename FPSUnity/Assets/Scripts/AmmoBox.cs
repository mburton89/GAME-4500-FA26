using System.Collections;
using UnityEngine;
using TMPro;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private int gainAmount = 10;
    [SerializeField] private float respawnTime = 10f;
    private Cannon cannon;

    private Collider boxCollider;
    private Renderer boxRenderer;

    [SerializeField] private float rotationSpeed = 100f;

    private TextMeshProUGUI ammoText;

    private void Awake()
    {
        GameObject cannonObject = GameObject.FindGameObjectWithTag("Cannon");

        if (cannonObject != null)
        {
            print("Got cannon");
            cannon = cannonObject.GetComponent<Cannon>();
        }

        GameObject ammoTextObject = GameObject.Find("TMP - Ammo");

        if (ammoTextObject != null)
        {
            ammoText = ammoTextObject.GetComponent<TextMeshProUGUI>();
        }

        boxCollider = GetComponent<Collider>();
        boxRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (cannon.ammo >= 20)
        {
            return;
        }

        if (!other.GetComponent<FPSController>())
        {
            print("Not a player");
            return;
        }

        if (cannon == null)
        {
            print("No cannon");
            return;
        }

        cannon.ammo = Mathf.Clamp(cannon.ammo + gainAmount, 0, 20);
        ammoText.text = "Ammo: " + cannon.ammo  +" / " + cannon.maxAmmo;

        boxCollider.enabled = false;
        boxRenderer.enabled = false;

        StartCoroutine(Reactivate(respawnTime));
    }

    private IEnumerator Reactivate(float time)
    {
        yield return new WaitForSeconds(time);

        boxCollider.enabled = true;
        boxRenderer.enabled = true;
    }
}
