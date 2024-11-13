using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    static bool paused = false;
    public GameObject PauseMenuCanvas;
    void Start()
    {
        Time.timeScale = 1f;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                PlayGame();
            }
            else
            {
                StopGame();
            }
        }
    }

    void StopGame()
    {
        PauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            paused = true;
    }

    public void PlayGame()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
