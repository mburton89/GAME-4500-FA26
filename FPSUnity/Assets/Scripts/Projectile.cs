using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damageToGive;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Zombie>())
        {
            //we've collided with a zombie
            collision.gameObject.GetComponent<Zombie>().TakeDamage(damageToGive);
        }

        //add destroy object later

    }




}
