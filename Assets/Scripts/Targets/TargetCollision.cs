using System;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStatesEvent; // ouvinte
    [SerializeField] private ParticleSystem explosionParticle; // Refêrencia direta para o sistema de partículas
    [SerializeField] private int scoreValue; // Valor de score que o game object
    
    public static event Action<int> TargetDestroyed; // Ação que ocorre toda vez que um objeto é destruído
    
    private void OnMouseDown() // Quando o mouse está sobre o objeto e é clicado
    {
        if (gameStatesEvent.gameStateAtual == GameState.Playing) // O método verifica se o estádo do jogo está como "Playing"
        {
            TargetDestroyed?.Invoke(scoreValue); // A ação então é invocada, passando o valor de score do objeto
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); // O sistema de partícula é instanciada na posição do objeto que foi clicado
            Destroy(gameObject); // O objeto clicado então é destruído
        }
    }
}
