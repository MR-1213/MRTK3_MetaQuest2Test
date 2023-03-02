using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnController : MonoBehaviour
{
    [SerializeField, Tooltip("The distance from the GameObject's spawn position at which will trigger a respawn.")]
    private float distanceThreshold = 20.0f;

    private Vector3 localRespawnPosition;
    private Quaternion localRespawnRotation;
    private Rigidbody rigidBody;
    private float distanceThresholdSquared;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        localRespawnPosition = transform.localPosition;
        localRespawnRotation = transform.localRotation;
        distanceThresholdSquared = distanceThreshold * distanceThreshold;
    }

    private void LateUpdate()
    {
        float distanceSqr = (localRespawnPosition - transform.localPosition).sqrMagnitude;

        if (distanceSqr > distanceThresholdSquared)
        {
            // Reset any velocity from falling or moving when respawning to original location
            if (rigidBody != null)
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.angularVelocity = Vector3.zero;
            }

            transform.localPosition = localRespawnPosition;
            transform.localRotation = localRespawnRotation;
        }
    }
    
}
