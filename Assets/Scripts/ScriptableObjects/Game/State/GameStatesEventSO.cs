using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/GameStateEvent")]
public class GameStatesEventSO : ScriptableObject
{
    public event Action<GameState> OnRaised;
    public GameState gameStateAtual;

    private void OnEnable()
    {
        OnRaised = null;
    }

    public void Raise(GameState state)
    {
        gameStateAtual = state;
        OnRaised?.Invoke(state);
    }
}

