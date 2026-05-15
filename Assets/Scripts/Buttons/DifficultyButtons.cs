using System;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStateEvent;
    [SerializeField] private DifficultyEventSO difficultyEvent;
    [SerializeField] private DifficultySettingsSO[] difficultySettings;

    private void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>();

        foreach (Button btn in buttons)
        {
            Button localBtn = btn;
            localBtn.onClick.AddListener(() => SetDifficulty(localBtn));
        }
    }

    private void SetDifficulty(Button btn)
    {
        DifficultyLevel level = btn.name switch
        {
            "EasyMode Button"   => DifficultyLevel.Easy,
            "MediumMode Button" => DifficultyLevel.Medium,
            "HardMode Button"   => DifficultyLevel.Hard,
            _                   => DifficultyLevel.Easy
        };

        difficultyEvent.Raise(level);
        gameStateEvent.Raise(GameState.Playing);
    }
}
