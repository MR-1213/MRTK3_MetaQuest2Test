using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnController : MonoBehaviour
{
    [SerializeField, Tooltip("The distance from the GameObject's spawn position at which will trigger a respawn.")]
    private float distanceThreshold = 30.0f;

    private Vector3 localRespawnPosition;
    private Quaternion localRespawnRotation;
    private Rigidbody rigidBody;
    private float distanceThresholdSquared;

    private void Awake() 
    {
        if(distanceThreshold < 0)
        {
            Debug.LogError("distanceThresholdの値は正の値を指定してください");
        }
    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        localRespawnPosition = transform.localPosition;
        localRespawnRotation = transform.localRotation;
        distanceThresholdSquared = distanceThreshold * distanceThreshold;
    }

    private void LateUpdate()
    {
        //カッコ内の値はマイナスの値になる可能性があるので2乗してその値で考える
        float distanceSqr = (localRespawnPosition - transform.localPosition).sqrMagnitude;
        //現在のY座標を取得
        float currentPositionY = transform.localPosition.y;

        if (distanceSqr > distanceThresholdSquared && currentPositionY < -3)
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
