using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damageToGive;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Zombie>())
        {
            //We've collided with a zombie, oh no! What are we gonna do?

            collision.gameObject.GetComponent<Zombie>().TakeDamage(damageToGive);


        }
    }

}
