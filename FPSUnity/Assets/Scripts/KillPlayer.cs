using Unity.VisualScripting;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.GetComponent<FPSController>())
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<FPSController>())
        {
            GameManager.Instance.GameOver();
        }
    }
}
