using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStateEvent;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;

    private void OnEnable()
    {
        gameStateEvent.OnRaised += HandleStateChanged;
    }

    private void OnDisable()
    {
        gameStateEvent.OnRaised -= HandleStateChanged;
    }

    private void HandleStateChanged(GameState state)
    {
        if (startPanel == null || gameOverPanel == null) return;
        
        startPanel.SetActive(state == GameState.Start);
        gameOverPanel.SetActive(state == GameState.GameOver);
    }
}
