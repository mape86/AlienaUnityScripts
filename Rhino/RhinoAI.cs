using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class RhinoAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float chaseRadius = 8f;
    [SerializeField] float attackDamage = 5f;
    NavMeshAgent rhino;
    NavMeshAgent rhino1;
    NavMeshAgent rhino2;
    NavMeshAgent rhino3;
    PlayerEnergyLevel playerEnergyLevel;

    float distanceToPlayer = Mathf.Infinity;
    bool isProvoked = false;
    bool takeDamage = true;

    private float damageTime = 1.4f;

    private Animator animator;

    private AudioSource audioSource;

    public AudioClip attackSound;





    void Start()
    {
        rhino = GetComponent<NavMeshAgent>();

        rhino1 = GameObject.FindGameObjectWithTag("Rhino1").GetComponent<NavMeshAgent>();
        rhino2 = GameObject.FindGameObjectWithTag("Rhino2").GetComponent<NavMeshAgent>();
        rhino3 = GameObject.FindGameObjectWithTag("Rhino3").GetComponent<NavMeshAgent>();

        playerEnergyLevel = player.GetComponent<PlayerEnergyLevel>();

        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        EngagementHandler();
    }
    //Method to handle the rhinos engagement with the player.
    private void EngagementHandler()
    {
        if (rhino1 != null)
        {

            distanceToPlayer = Vector3.Distance(player.position, transform.position);
            if (isProvoked)
            {
                if (distanceToPlayer >= rhino.stoppingDistance)
                {
                    ChasePlayer();
                }
                if (distanceToPlayer <= rhino.stoppingDistance)
                {
                    AttackPlayer();
                }

            }
            if (distanceToPlayer <= chaseRadius)
            {
                isProvoked = true;
            }
            if (distanceToPlayer >= chaseRadius && isProvoked == true)
            {
                isProvoked = false;
                rhino1.GetComponent<Rhino1Patrol>().HandleRhino1Movement();
                animator.SetBool("isChasing", false);
                animator.SetBool("isAttacking", false);
                animator.SetBool("isMoving", true);
                rhino.speed = 0.6f;

            }
        }
        else if (rhino2)
        {

            distanceToPlayer = Vector3.Distance(player.position, transform.position);
            if (isProvoked)
            {
                if (distanceToPlayer >= rhino.stoppingDistance)
                {
                    ChasePlayer();
                }
                if (distanceToPlayer <= rhino.stoppingDistance)
                {
                    AttackPlayer();
                }

            }
            if (distanceToPlayer <= chaseRadius)
            {
                isProvoked = true;
            }
            if (distanceToPlayer >= chaseRadius && isProvoked == true)
            {
                isProvoked = false;
                rhino2.GetComponent<Rhino2Patrol>().HandleRhino2Movement();
                animator.SetBool("isChasing", false);
                animator.SetBool("isAttacking", false);
                animator.SetBool("isMoving", true);
                rhino.speed = 0.6f;
            }
        }
        else if (rhino3)
        {

            distanceToPlayer = Vector3.Distance(player.position, transform.position);
            if (isProvoked)
            {
                if (distanceToPlayer >= rhino.stoppingDistance)
                {
                    ChasePlayer();
                }
                if (distanceToPlayer <= rhino.stoppingDistance)
                {
                    AttackPlayer();
                }
            }
            if (distanceToPlayer <= chaseRadius)
            {
                isProvoked = true;
            }
            if (distanceToPlayer >= chaseRadius && isProvoked == true)
            {
                isProvoked = false;
                rhino3.GetComponent<Rhino3Patrol>().HandleRhino3Movement();
                animator.SetBool("isChasing", false);
                animator.SetBool("isAttacking", false);
                animator.SetBool("isMoving", true);
                rhino.speed = 0.6f;
            }

        }

    }

    private void ChasePlayer()
    {
        animator.SetBool("isChasing", true);
        rhino.SetDestination(player.position);
        rhino.speed = 3;
    }

    private void AttackPlayer()
    {
        animator.SetBool("isChasing", false);
        animator.SetBool("isAttacking", true);
    }

    private void DealDamage()
    {
        playerEnergyLevel.LoseEnergy(attackDamage);
        audioSource.PlayOneShot(attackSound);
    }

    //Deals damage to the player as long as player is touching the rhinos collider. 
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && takeDamage)
        {
            DealDamage();
            StartCoroutine(DamageController());
        }
    }

    //Controls how often the player can take damage from attacks.
    private IEnumerator DamageController()
    {
        takeDamage = false;

        yield return new WaitForSeconds(damageTime);

        takeDamage = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(2, 2, 0, 1.25f);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}