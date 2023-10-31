using UnityEngine;
using UnityEngine.AI;

public class Rhino1Patrol : MonoBehaviour
{
    [SerializeField] private Transform movePosition1;
    [SerializeField] private Transform movePosition2;

    private NavMeshAgent rhino1Agent;

    private bool goBackRhino1;

    private void Awake()
    {
        rhino1Agent = GetComponent<NavMeshAgent>();

    }

    private void Start()
    {

    }

    private void Update()
    {
        HandleRhino1Movement();
    }

    //method to handle the movment of the rhino. Sets it to patrol between two points.
    public void HandleRhino1Movement()
    {
        if (goBackRhino1 == true)
        {
            rhino1Agent.SetDestination(movePosition2.position);
            if (!rhino1Agent.pathPending)
            {
                if (rhino1Agent.remainingDistance <= rhino1Agent.stoppingDistance)
                {
                    rhino1Agent.SetDestination(movePosition1.position);
                    goBackRhino1 = false;

                }
            }
        }
        else
        {
            rhino1Agent.SetDestination(movePosition1.position);
            if (!rhino1Agent.pathPending)
            {
                if (rhino1Agent.remainingDistance <= rhino1Agent.stoppingDistance)
                {
                    goBackRhino1 = true;
                }
            }
        }
    }

}
