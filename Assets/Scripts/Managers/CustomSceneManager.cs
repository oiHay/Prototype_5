using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
   [SerializeField] private GameStatesEventSO gameStatesEvent;
   
   public void ResetScene()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      gameStatesEvent.Raise(GameState.Playing);
   }

   public void GoToStart()
   {
      gameStatesEvent.Raise(GameState.Start);
   }
}
