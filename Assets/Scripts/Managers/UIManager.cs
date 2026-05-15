using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStateEvent; // Referência direta o GameStateEventSO
    [SerializeField] private GameObject startPanel; // Refêrencia ao panel que deve aparecer durante o estado de Start do jogo
    [SerializeField] private GameObject gameOverPanel; // Refêrencia ao panel que deve aparecer durante o estado de Game Over do jogo

    private void OnEnable()
    {
        gameStateEvent.OnRaised += HandleStateChanged; // Inscreve esse script como ouvinte do GameStateEventSO enquanto o objeto estiver ativo
    }

    private void OnDisable()
    {
        gameStateEvent.OnRaised -= HandleStateChanged; // Remove esse script da lista de ouvintes quando o objeto for desativado ou destruído
    }

    private void HandleStateChanged(GameState state) // Método que serve como ouvinte do GameStateEventSO, toda vez que o GameState muda de valor, esse código verifica para qual mudou e faz o que for preciso referente a mudança
    {
        if (startPanel == null || gameOverPanel == null) return; // Proteção contra referências destruídas, evita o erro MissingReferenceException
        
        startPanel.SetActive(state == GameState.Start); // Se o estado do jogo for "Start", o startPanel deve estar ativo
        gameOverPanel.SetActive(state == GameState.GameOver); // Se o estado do jogo for "GameOver", o GameOverPanel deve estar ativo
    }
}
