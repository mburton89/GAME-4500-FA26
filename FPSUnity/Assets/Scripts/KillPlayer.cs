using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Collided with something
        if (collision.gameObject.GetComponent<FPSController>())
        {
            //Collided with the player
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Collided with something
        if (other.gameObject.GetComponent<FPSController>())
        {
            //Collided with the player
            GameManager.Instance.GameOver();
        }
    }
}
