using UnityEngine;
using UnityEngine.AI;

public class Rhino2Patrol : MonoBehaviour
{
    [SerializeField] private Transform movePosition3;
    [SerializeField] private Transform movePosition4;

    private NavMeshAgent rhino2Agent;

    private Animator animatorRhino2;

    private bool goBackRhino2;


    private void Awake()
    {
        rhino2Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {

    }

    private void Update()
    {

        HandleRhino2Movement();

    }

    //method to handle the movment of the rhino. Sets it to patrol between two points.
    public void HandleRhino2Movement()
    {
        if (goBackRhino2 == true)
        {
            rhino2Agent.SetDestination(movePosition3.position);
            if (!rhino2Agent.pathPending)
            {
                if (rhino2Agent.remainingDistance <= rhino2Agent.stoppingDistance)
                {
                    rhino2Agent.SetDestination(movePosition4.position);
                    goBackRhino2 = false;
                }
            }
        }
        else
        {
            rhino2Agent.SetDestination(movePosition4.position);
            if (!rhino2Agent.pathPending)
            {
                if (rhino2Agent.remainingDistance <= rhino2Agent.stoppingDistance)
                {
                    goBackRhino2 = true;
                }
            }
        }

    }

}

