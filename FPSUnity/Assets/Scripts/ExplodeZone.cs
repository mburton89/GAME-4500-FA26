using UnityEngine;

public class ExplodeZone : MonoBehaviour
{

    public float giveDamage;
    public GameObject explosionZone;
    public GameObject zookaProjectile;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Zombie>())
        {
            //we've collided with a zombie
            collision.gameObject.GetComponent<Zombie>().TakeDamage(giveDamage);

            



        }

    }
    
}
