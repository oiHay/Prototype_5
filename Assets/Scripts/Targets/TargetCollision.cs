using System;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private int scoreValue;
    [SerializeField] private GameStatesEventSO gameStatesEvent;
    
    public static event Action<int> TargetDestroyed;
    
    private void OnMouseDown()
    {
        if (gameStatesEvent.gameStateAtual == GameState.Playing)
        {
            TargetDestroyed?.Invoke(scoreValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
        }
    }
}
