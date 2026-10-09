using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //if we made it this far, we've collided with something

        if (collision.gameObject.GetComponent<FPSController>())
        {
            //if we made it this far, we've collided with THE PLAYER

            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if we made it this far, we've collided with something

        if (other.gameObject.GetComponent<FPSController>())
        {
            //if we made it this far, we've collided with THE PLAYER

            GameManager.Instance.GameOver();
        }
    }
}
