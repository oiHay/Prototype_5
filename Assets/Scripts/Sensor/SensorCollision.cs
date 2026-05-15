using UnityEngine;

public class SensorCollision : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStatesEvent; // ouvinte
    [SerializeField] private GameManager gameManager; // broadcaster

    private bool _isGameActive = false; // Boolean que determina ao script se o jogo está ativo ou não
    
    private void Start()
    {
        _isGameActive = gameStatesEvent.gameStateAtual == GameState.Playing; // sincroniza ao iniciar caso tenha perdido o evento
    }
    
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
        if (!_isGameActive)
        {
            Destroy(other.gameObject); // Tendo tag ou não, os objetos que colidem com o trigger são destruídos
        }
        else
        {
            if (!other.CompareTag("Bad")) // Se um objeto que não tiver a tag "Bad" colidir com o objeto desse script
            {
                gameManager.ChangeState(GameState.GameOver); // O método de mudança de estado do game manager é chamado
            }
        
            Destroy(other.gameObject); // Tendo tag ou não, os objetos que colidem com o trigger são destruídos
        }
    }
}
