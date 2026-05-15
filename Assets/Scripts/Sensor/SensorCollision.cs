using UnityEngine;

public class SensorCollision : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStatesEvent;

    private bool _isGameActive = false;
    
    private void OnEnable()
    {
        gameStatesEvent.OnRaised += HandleStateChanged;
    }

    private void OnDisable()
    {
        gameStatesEvent.OnRaised -= HandleStateChanged;
    }

    private void HandleStateChanged(GameState state)
    {
        _isGameActive = state == GameState.Playing;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"Sensor hit by: {other.gameObject.name} | Tag: {other.gameObject.tag}");
        
        if(!_isGameActive) return;
        
        if (!other.CompareTag("Bad"))
        {
            gameStatesEvent.Raise(GameState.GameOver);
        }
        
        Destroy(other.gameObject);
    }
}
