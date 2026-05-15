using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStateEvent;
    [SerializeField] private DifficultyEventSO difficultyEvent;
    [SerializeField] private DifficultySettingsSO[] difficultySettings;
    [SerializeField] private List<GameObject> targets;
    // [SerializeField] private float spawnRate = 1.0f;

    private float _spawnRate;
    private bool _isGameActive = false;
    private DifficultySettingsSO _currentDifficulty;
    
    private void OnEnable()
    {
        gameStateEvent.OnRaised += HandleStateChanged;
        difficultyEvent.OnRaised += SetDifficulty;
    }

    private void OnDisable()
    {
        gameStateEvent.OnRaised -= HandleStateChanged;
        difficultyEvent.OnRaised -= SetDifficulty;
    }
    
    private void SetDifficulty(DifficultyLevel level)
    {
        _currentDifficulty = Array.Find(difficultySettings, d => d.level == level);
        _spawnRate = _currentDifficulty.spawnRate;
        
        Debug.Log("spawn Rate value = " +_spawnRate);
    }
    
    private IEnumerator SpawnTarget()
    {
        while (_isGameActive) 
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    private void HandleStateChanged(GameState state)
    {
        _isGameActive = state == GameState.Playing;
        StopAllCoroutines();

        if (state == GameState.Playing)
        {
            StartCoroutine(SpawnTarget());
        }
        // else if (state == GameState.GameOver || state == GameState.Start)
        // {
        //     DestroyAllTargets();
        // }
    }

    // private void DestroyAllTargets()
    // {
    //     foreach (GameObject target in GameObject.FindGameObjectsWithTag("Target"))
    //     {
    //         Destroy(target);
    //     }
    // }
}
