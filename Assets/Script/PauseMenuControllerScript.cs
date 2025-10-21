using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControllerScript : MonoBehaviour
{
    
    public void OnPausePressed()
    {
        Time.timeScale = 0f;
    }

    public void OnResumePressed()
    {
        Time.timeScale = 1f;
    }

    public void OnRestartPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void OnMainMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
