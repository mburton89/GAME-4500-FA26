using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    public float moveSpeed;
    public float maxHealth;
    public float currentHealth;

    public GameObject zombieGuts;

    public AudioSource takeDamageSound;

    Transform target;
    NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        target = FindObjectOfType<FPSController>().transform;

        agent = GetComponent<NavMeshAgent>();

        agent.speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }
    
    void ChasePlayer()
    {
        agent.destination = target.position;
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        takeDamageSound.Play();
 
        if(currentHealth <= 0)
        {
            Instantiate(zombieGuts, transform.position, transform.rotation, null);
            Destroy(gameObject);
        }
    }

    //add GiveDamage later

}
