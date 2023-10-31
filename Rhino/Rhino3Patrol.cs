using UnityEngine;
using UnityEngine.AI;

public class Rhino3Patrol : MonoBehaviour
{
    [SerializeField] private Transform movePosition5;
    [SerializeField] private Transform movePosition6;

    private NavMeshAgent rhino3Agent;

    private Animator animatorRhino3;

    private bool goBackRhino3;


    private void Awake()
    {
        rhino3Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        HandleRhino3Movement();
    }

    //method to handle the movment of the rhino. Sets it to patrol between two points.
    public void HandleRhino3Movement()
    {

        if (goBackRhino3 == true)
        {
            rhino3Agent.SetDestination(movePosition6.position);
            if (!rhino3Agent.pathPending)
            {
                if (rhino3Agent.remainingDistance <= rhino3Agent.stoppingDistance)
                {
                    rhino3Agent.SetDestination(movePosition5.position);
                    goBackRhino3 = false;
                }
            }
        }
        else
        {
            rhino3Agent.SetDestination(movePosition5.position);
            if (!rhino3Agent.pathPending)
            {
                if (rhino3Agent.remainingDistance <= rhino3Agent.stoppingDistance)
                {
                    goBackRhino3 = true;
                }
            }
        }
    }

}

