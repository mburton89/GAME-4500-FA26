using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    public float moveSpeed;
    public float maxHealth;
    float currentHealth;

    Transform target;
    NavMeshAgent agent;

    public GameObject zombieGuts;

    public AudioSource takeDamageSound;

    public Image healthBarFill;

    public GameObject healthBarCanvas;

    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        target = FindObjectOfType<FPSController>().transform;

        agent = GetComponent<NavMeshAgent>();

        agent.speed = moveSpeed;

        healthBarCanvas.gameObject.SetActive(false);
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

    public void TakeDamage(float damgeToTake)
    {
        currentHealth -= damgeToTake;
        takeDamageSound.Play();

        healthBarFill.fillAmount = currentHealth / maxHealth;

        healthBarCanvas.gameObject.SetActive(true);

        if (currentHealth <= 0)
        {
            Instantiate(zombieGuts, transform.position, transform.rotation, null);
            ZombieSpawner.Instance.CountCurrentZombies();
            Destroy(gameObject);
        }
    }
    
    public void Attack()
    {
        animator.parameters.SetValue(1, 0); // Doesn't Work
    }
}
