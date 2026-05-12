using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/GameStateEvent")]
public class GameStatesEventSO : ScriptableObject
{
    public event Action<GameState> OnRaised;

    public GameState gameStateAtual;

    public void Raise(GameState state)
    {
        OnRaised?.Invoke(state);
    }
}

