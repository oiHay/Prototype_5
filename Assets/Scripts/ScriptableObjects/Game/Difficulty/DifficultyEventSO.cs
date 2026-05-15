using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/DifficultyEvent")]
public class DifficultyEventSO : ScriptableObject
{
    public event Action<DifficultyLevel> OnRaised; // Action que dita a dificuldade que o jogo se encontra

    private void OnEnable()
    {
        OnRaised = null; // Toda vez que é recriado ele limpa a lista de scripts que ouviam esse, serve para evitar o erro MissingReferenceException
    }

    public void Raise(DifficultyLevel level)
    {
        OnRaised?.Invoke(level); // Notifica todos os scripts inscritos que a dificuldade do jogo mudou
    }
}
