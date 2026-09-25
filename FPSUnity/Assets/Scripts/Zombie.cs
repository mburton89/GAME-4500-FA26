using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    public float moveSpeed;

    public float maxHealth;
    float currentHeath;

    Transform target;
    NavMeshAgent agent;

    public GameObject zombieGuts;

    public AudioSource takeDamageSound;

    public Image healthBarFill;

    public GameObject healthBarCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHeath = maxHealth;

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

    public void TakeDamage(float damageToTake)
    {
        currentHeath -= damageToTake;
        takeDamageSound.Play();

        healthBarFill.fillAmount = currentHeath / maxHealth;

        healthBarCanvas.gameObject.SetActive(true);

        if(currentHeath <= 0)
        {
            Instantiate(zombieGuts, transform.position, transform.rotation, null);
            ZombieSpawner.Instance.countCurrentZombies();
            Destroy(gameObject);
        }
    }

    //give damage??

}
