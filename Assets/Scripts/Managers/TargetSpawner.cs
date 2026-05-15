using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStateEvent; // Referencia direta ao GameStateEventSO, permite que o código saiba qual é o estado atual do jogo
    [SerializeField] private DifficultyEventSO difficultyEvent; // Referência direta ao difficulty event scriptableObject
    [SerializeField] private DifficultySettingsSO[] difficultySettings; // Referência direta aos scriptableObjects de modos de dificuldade do jogo
    [SerializeField] private List<GameObject> targets; // Referência direta aos prefabs que podem ser instanciados pelo script

    private float _spawnRate; // Variável que determina o valor de spawnRate
    private bool _isGameActive = false; // Boolean que determina ao script se o jogo está ativo ou não
    private DifficultySettingsSO _currentDifficulty; // Variável que guarda qual a dificuldade atual da cena
    
    private void OnEnable()
    {
        gameStateEvent.OnRaised += HandleStateChanged; // Inscreve esse script como ouvinte do GameStateEventSO enquanto o objeto estiver ativo
        difficultyEvent.OnRaised += SetDifficulty; // Inscreve esse script como ouvinte do DifficultyEventSO enquanto o objeto estiver ativo
    }

    private void OnDisable()
    {
        gameStateEvent.OnRaised -= HandleStateChanged; // Remove esse script da lista de ouvintes quando o objeto for desativado ou destruído
        difficultyEvent.OnRaised -= SetDifficulty; // Remove esse script da lista de ouvintes quando o objeto for desativado ou destruído
    }
    
    private void SetDifficulty(DifficultyLevel level)
    {
        _currentDifficulty = Array.Find(difficultySettings, d => d.level == level); // Percorre o array difficultySettings procurando o SO cuja dificuldade corresponde ao level recebido
        _spawnRate = _currentDifficulty.spawnRate; // Atualiza o spawnRate com o valor configurado no SO da dificuldade escolhida
        
        #if UNITY_EDITOR //garante que o debug.log só rode durante o unity editor e que não vá para a build final
        Debug.Log("spawn Rate value = " +_spawnRate);
        #endif
    }
    
    private IEnumerator SpawnTarget()
    {
        while (_isGameActive) // Enquanto a variável _isGameActive for ativa
        {
            yield return new WaitForSeconds(_spawnRate); // Ela roda em intervalos de tempo referentes ao valor de _spawnRate
            int index = Random.Range(0, targets.Count); // Cria um index com o número máximo de prefabs listados e seleciona um deles de forma randomica
            Instantiate(targets[index]); // Pega o selecionado e instancia ele na cena
        }
    }

    private void HandleStateChanged(GameState state)
    {
        _isGameActive = state == GameState.Playing; // Se o estádo do jogo se tornar "Playing", a boolean _isGameActive se torna verdadeira
        StopAllCoroutines(); // Todas as coroutines que existiam antes são paradas

        if (state == GameState.Playing) // Assim, se o estado for "Playing"
        {
            StartCoroutine(SpawnTarget()); // Os prefabs podem ser instanciados na cena
        }
    }
}
