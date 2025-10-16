using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuUI;
        
    public void OnPausePress()
    {
        pauseMenuUI.SetActive(true); //shows pause UI
        Time.timeScale = 0f; // Freezes game time
    }
    public void OnContinuePress()
    {
        Time.timeScale = 1f; //resumes the game
        pauseMenuUI.SetActive(false); //hides pause UI
        
    }

    public void OnRestartPress()
    {
        Time.timeScale = 1f; //this is important , if not set, game freezes while reloding!
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    public void OnExitPress()
    {
        Application.Quit();
    }
    
}
