using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetBehaviour : MonoBehaviour
{
    [SerializeField] private float minSpeed = 12f;
    [SerializeField] private float maxSpeed = 16f;
    [SerializeField] private float maxTorque = 2f;
    [SerializeField] private float xRange = 4f;
    [SerializeField] private float ySpawnPos = -6f;
    
    private Rigidbody _targetRb;

    private void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
        
        _targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque,maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
