using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStatesEvent;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreTotalText;
    
    private int _score;

    private void OnEnable()
    {
        gameStatesEvent.OnRaised += HandleStateChanged;
        TargetCollision.TargetDestroyed += HandleTargetDestroyed;
    }

    private void OnDisable()
    {
        gameStatesEvent.OnRaised -= HandleStateChanged;
        TargetCollision.TargetDestroyed -= HandleTargetDestroyed;
    }

    private void HandleStateChanged(GameState state)
    {
        if (state != GameState.Playing) return;
        _score = 0;
        scoreText.text = "Score: " + _score;
    }

    private void HandleTargetDestroyed(int amount)
    {
        if(!scoreText) return;
        _score += amount;
        scoreText.text = "Score: " + _score;
        scoreTotalText.text = "Your total score was: " + _score;
    }
}
