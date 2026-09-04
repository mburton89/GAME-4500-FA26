using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float moveSpeed;

    public float maxHeath;
    float currentHeath;

    Transform target;
    NavMeshAgent agent;

    public GameObject zombieGuts;

    public AudioSource takeDamageSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHeath = maxHeath;

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
        currentHeath -= damageToTake;
        takeDamageSound.Play();

        if(currentHeath <= 0)
        {
            Instantiate(zombieGuts, transform.position, transform.rotation, null);
            Destroy(gameObject);
        }
    }

    //give damage??

}
