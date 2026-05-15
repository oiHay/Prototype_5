using UnityEngine;

[CreateAssetMenu(menuName = "Settings/DifficultySettings")]
public class DifficultySettingsSO : ScriptableObject
{
    public DifficultyLevel level; // Referência direta ao enum de leveis de dificuldade
    public float spawnRate; // Determina que cada level tem seu spawnRate específico
}
