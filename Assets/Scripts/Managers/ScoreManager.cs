using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private int _score;

    private void Awake()
    {
        _score = 0;
        scoreText.text = "Score: " + _score;
    }

    private void OnEnable()
    {
        TargetCollision.TargetDestroyed += HandleTargetDestroyed;
    }

    private void OnDisable()
    {
        TargetCollision.TargetDestroyed -= HandleTargetDestroyed;
    }

    private void HandleTargetDestroyed(int amount)
    {
        _score += amount;
        scoreText.text = "Score: " + _score;
    }
}
