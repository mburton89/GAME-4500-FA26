using System.Collections;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private int gainAmount = 10;
    [SerializeField] private float respawnTime = 10f;
    [SerializeField] private Cannon cannon;

    [SerializeField] private float rotationSpeed = 100f;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        
       if (!other.GetComponent<FPSController>())
        {
            return;
        }

        cannon.ammo = Mathf.Clamp(cannon.ammo + 10, 0, 20);
        gameObject.SetActive(false);

        StartCoroutine(Reactivate(respawnTime));
    }

    private IEnumerator Reactivate(float time)
    {
        yield return new WaitForSeconds(time);

        gameObject.SetActive(true);
    }
}
