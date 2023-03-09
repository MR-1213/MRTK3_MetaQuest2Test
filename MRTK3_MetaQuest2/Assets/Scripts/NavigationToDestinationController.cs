using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationToDestinationController : MonoBehaviour
{
    public Transform destination_GFO;

    [SerializeField] private Transform cursor;

    private NavMeshAgent navMeshAgent;
    private float distanceThreshold = 5.0f;

    private void Start() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(destination_GFO.position);
        navMeshAgent.updatePosition = false;
        navMeshAgent.updateRotation = false;    
    }

    public void StartNavigation()
    {
        cursor.gameObject.SetActive(true);
        StartCoroutine(NavigationToDestination());
    }

    IEnumerator NavigationToDestination()
    {
        while(true)
        {
            float distance = (this.transform.position - destination_GFO.position).sqrMagnitude;
            if(distance < distanceThreshold * distanceThreshold)
            {
                cursor.gameObject.SetActive(false);
                yield break;
            }

            cursor.rotation = Quaternion.LookRotation(navMeshAgent.steeringTarget - transform.position, Vector3.up);
            navMeshAgent.nextPosition = transform.position;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
