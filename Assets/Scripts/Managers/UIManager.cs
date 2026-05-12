using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStateEvent;
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
        gameOverPanel.SetActive(state == GameState.GameOver);
    }
}
