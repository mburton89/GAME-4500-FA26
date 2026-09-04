using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float moveSpeed;

    public float maxHealth;
    float currentHealth;

    Transform target;
    NavMeshAgent agent;

    public GameObject zombieGuts;

    public AudioSource takeDamageSound;

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

        if (currentHealth <= 0)
        {
            Instantiate(zombieGuts, transform.position, transform.rotation, null);
            Destroy(gameObject);
        }
    }


}
