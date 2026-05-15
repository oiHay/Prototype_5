using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStatesEvent;  // Referencia direta ao GameStateEventSO, permite que o código saiba qual é o estado atual do jogo e que o mesmo possa ser alterado

    private static GameManager Instance { get; set; }

    private void Awake() // Singleton, permite que o game object que possui esse código persista durante loads da cena
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ChangeState(GameState.Start); // Quando o jogo é iniciado, o estado do jogo é alterado para start
    }

    // private void Update() 
    // { 
    //     Debug.Log(gameStatesEvent.gameStateAtual); // Debug para saber o estado atual do jogo
    // }

    public void ChangeState(GameState newState) // público para permitir que outros scripts alterem o estado
    {
        gameStatesEvent.Raise(newState); // Método que permite que o gameManager mude o valor do estado atual da cena
    }
}
