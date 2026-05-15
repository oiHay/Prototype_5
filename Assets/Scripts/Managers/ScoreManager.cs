using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStatesEvent; // Ouvinte
    [SerializeField] private TextMeshProUGUI scoreText; // Referência ao texto que mostra o score do player
    [SerializeField] private TextMeshProUGUI scoreTotalText; // Referência ao texto que mostra o score final do player
    
    private int _score; // Variável que guarda o valor atual de score do player

    private void OnEnable()
    {
        gameStatesEvent.OnRaised += HandleStateChanged; // Inscreve esse script como ouvinte do GameStateEventSO enquanto o objeto estiver ativo
        TargetCollision.TargetDestroyed += HandleTargetDestroyed; // Inscreve esse script como ouvinte do TargetCollision enquanto o objeto estiver ativo
    }

    private void OnDisable()
    {
        gameStatesEvent.OnRaised -= HandleStateChanged; // Remove esse script da lista de ouvintes quando o objeto for desativado ou destruído
        TargetCollision.TargetDestroyed -= HandleTargetDestroyed; // Remove esse script da lista de ouvintes quando o objeto for desativado ou destruído
    }

    private void HandleStateChanged(GameState state)
    {
        if (scoreText == null || scoreTotalText == null) return; // guard contra referências nulas
        if (state != GameState.Playing) return; // Se o estado do jogo não for "Playing", o resto do código do método não é lido
       
        _score = 0; // Caso seja, o score começa como 0
        scoreText.text = "Score: " + _score; // O texto de score então é atualizado conforme o score muda
    }

    private void HandleTargetDestroyed(int amount) // Quando um target é destruído
    {
        if (scoreText == null || scoreTotalText == null) return; // guard consistente
        _score += amount; // Caso tenha, o valor de score aumenta a partir de um valor, que é determinado pelo target em seu script de colisão 
        scoreText.text = "Score: " + _score; // O texto de score então é atualizado
        scoreTotalText.text = "Your total score was: " + _score; // O texto de score final é atualizado também
    }
}
