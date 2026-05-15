using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStatesEvent;
    
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ChangeState(GameState.Start);
    }

    private void Update()
    { 
        Debug.Log(gameStatesEvent.gameStateAtual);
    }

    public void ChangeState(GameState newState)
    {
        gameStatesEvent.Raise(newState);
    }
}
