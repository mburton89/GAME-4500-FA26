using UnityEngine;

public class Zooka_Projectile : MonoBehaviour
{

    public float giveDamage;
    public GameObject explosionZone;
    public GameObject zookaProjectile;
    public GameObject explodeEffect;
    public AudioClip explosionSound;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Zombie>())
        {
            //we've collided with a zombie
            ExplosionCollide();
            collision.gameObject.GetComponent<Zombie>().TakeDamage(giveDamage);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Destroy(zookaProjectile);
            Destroy(explosionZone, 1);


        }
        

    }
    private void ExplosionCollide()
    {
        
        Instantiate(explodeEffect, transform.position, transform.rotation, null);
        
    }
}
