using System;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{
    [SerializeField] private GameManager gameManager; // Referência direta ao game manager
    [SerializeField] private DifficultyEventSO difficultyEvent; // Referência direta ao difficulty event scriptableObject
    [SerializeField] private DifficultySettingsSO[] difficultySettings; // Referência direta aos scriptableObjects de modos de dificuldade do jogo

    private void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>(); // O game object pai inscreve todos os botões presentes como filhos

        foreach (Button btn in buttons) // Para cada botão presente nos botões filhos
        {
            Button localBtn = btn; // Um local é associado à cada filho
            localBtn.onClick.AddListener(() => SetDifficulty(localBtn)); // Quando um dos botões é clicado, ele é inscrito como ouvinte do método que seta a dificuldade da cena
        }
    }

    private void SetDifficulty(Button btn)
    {
        DifficultyLevel level = btn.name switch // Switch é uma forma mais simples e eficiente de fazer longas linhas de if-else e é uma boa prática para lidar com enums
        {
            "EasyMode Button"   => DifficultyLevel.Easy, // Quando o botão denominado "EasyMode Button" é clicado, o valor do enum de level de dificuldade se torna "easy"
            "MediumMode Button" => DifficultyLevel.Medium, // Quando o botão denominado "MediumMode Button" é clicado, o valor do enum de level de dificuldade se torna "medium"
            "HardMode Button"   => DifficultyLevel.Hard, // Quando o botão denominado "HardMode Button" é clicado, o valor do enum de level de dificuldade se torna "hard"
            _                   => DifficultyLevel.Easy // Caso nenhum botão seja selecionado, o valor default de dificuldade é "easy"
        };

        difficultyEvent.Raise(level); // O método de mudança de dificuldade é chamado (ligação direta com o código, não passa por um controlador como gameManager por não ser necessário)
        gameManager.ChangeState(GameState.Playing); // O método de mudança de estado do game manager é chamado
    }
}
