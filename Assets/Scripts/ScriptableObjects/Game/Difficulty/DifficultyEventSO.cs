using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/DifficultyEvent")]
public class DifficultyEventSO : ScriptableObject
{
    public event Action<DifficultyLevel> OnRaised;

    private void OnEnable()
    {
        OnRaised = null;
    }

    public void Raise(DifficultyLevel level)
    {
        OnRaised?.Invoke(level);
    }
}
