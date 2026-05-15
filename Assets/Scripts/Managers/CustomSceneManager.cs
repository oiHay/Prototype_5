using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
   [SerializeField] private GameManager gameManager; // Referência direta ao game manager
   
   public void ResetScene() // Quando a cena é resetada
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name); // O scene manager da load na cena avita atualmente
      gameManager.ChangeState(GameState.Playing); // Então o método de mudança de estado do game manager é chamado
   }

   public void GoToStart() // Quando o jogo é direcionado ao seu início
   {
      gameManager.ChangeState(GameState.Start); // O método de mudança de estado do game manager é chamado
   }
}
