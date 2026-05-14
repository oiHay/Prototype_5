using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
   public void ResetScene()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      GameManager.Instance.ChangeState(GameState.Playing);
   }
    
}
