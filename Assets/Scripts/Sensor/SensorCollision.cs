using UnityEngine;

public class SensorCollision : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStatesEvent; // ouvinte
    [SerializeField] private GameManager gameManager; // broadcaster

    private bool _isGameActive = false; // Boolean que determina ao script se o jogo está ativo ou não
    
    private void OnEnable()
    {
        gameStatesEvent.OnRaised += HandleStateChanged; // Inscreve esse script como ouvinte do GameStateEventSO enquanto o objeto estiver ativo
    }

    private void OnDisable()
    {
        gameStatesEvent.OnRaised -= HandleStateChanged; // Remove esse script da lista de ouvintes quando o objeto for desativado ou destruído
    }

    private void HandleStateChanged(GameState state)
    {
        _isGameActive = state == GameState.Playing; // Caso o modo de jogo seja "Playing", a boolean _isGameActive se torna verdadeira
    }
    
    private void OnTriggerEnter(Collider other) // Quando um objeto colide com o objeto que possui esse script
    {
        if(!_isGameActive) return; // O script verifica se a boolean _isGameActive é verdadeira, se for falsa, a leitura não continua
        
        if (!other.CompareTag("Bad")) // Se um objeto que não tiver a tag "Bad" colidir com o objeto desse script
        {
            gameManager.ChangeState(GameState.GameOver); // O método de mudança de estado do game manager é chamado
        }
        
        Destroy(other.gameObject); // Tendo tag ou não, os objetos que colidem com o trigger são destruídos
    }
}
