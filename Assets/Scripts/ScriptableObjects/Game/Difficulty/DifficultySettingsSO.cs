using UnityEngine;

[CreateAssetMenu(menuName = "Settings/DifficultySettings")]
public class DifficultySettingsSO : ScriptableObject
{
    public DifficultyLevel level;
    public float spawnRate;
}
