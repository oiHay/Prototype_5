using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float spawnRate = 1.0f;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    private IEnumerator SpawnTarget()
    {
        while (true) 
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
