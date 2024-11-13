using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
  public void PlayGame() // Starting the next scene from the main menu
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void QuitGame() // Quiting the game from the main menu
  {
    Application.Quit();
  }
}
