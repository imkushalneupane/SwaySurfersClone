using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControllerScript : MonoBehaviour
{

    public float sceneLoadDelay = 0.1f;

    public void OnPausePressed()
    {
        StartCoroutine(PauseScene());
    }

    IEnumerator PauseScene()
    {
        yield return  new WaitForSeconds(.3f);
        Time.timeScale = 0f;
    }

    public void OnResumePressed()
    {
        Time.timeScale = 1f;
    }

    public void OnRestartPressed()
    {
        Time.timeScale = 1f;
        Invoke(nameof(RestartScene), sceneLoadDelay);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenuPressed()
    {
        Invoke(nameof(LoadMainMenu), sceneLoadDelay);
        Time.timeScale = 1f;
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
