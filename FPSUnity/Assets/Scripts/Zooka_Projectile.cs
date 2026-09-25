using UnityEngine;

public class Zooka_Projectile : MonoBehaviour
{

    public float giveDamage;
    public GameObject explosionZone;
    public GameObject zookaProjectile;
    public GameObject explodeEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Zombie>())
        {
            //we've collided with a zombie
            ExplosionCollide();
            collision.gameObject.GetComponent<Zombie>().TakeDamage(giveDamage);
            Destroy(zookaProjectile);
            


        }

    }
    private void ExplosionCollide()
    {
        Instantiate(explosionZone);
        Instantiate(explodeEffect);

    }
}
