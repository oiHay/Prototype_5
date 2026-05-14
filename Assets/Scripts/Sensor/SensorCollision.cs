using UnityEngine;

public class SensorCollision : MonoBehaviour
{
    [SerializeField] private GameStatesEventSO gameStatesEvent;
    
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"Sensor hit by: {other.gameObject.name} | Tag: {other.gameObject.tag}");
        
        if (!other.CompareTag("Bad"))
        {
            gameStatesEvent.Raise(GameState.GameOver);
        }
        
        Destroy(other.gameObject);
    }
}
