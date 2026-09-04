using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damageToGive;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Zombie>())
        {
            //Collision with Zombie
            collision.gameObject.GetComponent<Zombie>().TakeDamage(damageToGive);
            Destroy(gameObject);
        }
    }
}
