using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationToDestinationController : MonoBehaviour
{
    public Transform destination_GFO;

    [SerializeField] private Transform cursor;

    private NavMeshAgent navMeshAgent;

    private void Start() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(destination_GFO.position);
        navMeshAgent.updatePosition = false;
        navMeshAgent.updateRotation = false;    
    }

    private void Update() 
    {
        cursor.rotation = Quaternion.LookRotation(navMeshAgent.steeringTarget - transform.position, Vector3.up);
        navMeshAgent.nextPosition = transform.position;
    }
}
