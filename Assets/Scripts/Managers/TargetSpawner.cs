using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStateEvent;   
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float spawnRate = 1.0f;

    private bool _isGameActive = false;
    
    private IEnumerator SpawnTarget()
    {
        while (_isGameActive) 
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    
    private void OnEnable()
    {
        gameStateEvent.OnRaised += HandleStateChanged;
    }

    private void OnDisable()
    {
        gameStateEvent.OnRaised -= HandleStateChanged;
    }

    private void HandleStateChanged(GameState state)
    {
        _isGameActive = state == GameState.Playing;
        
        if (state == GameState.Playing)
        {
            StartCoroutine(SpawnTarget());
        }
    }
}
