using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllerScript : MonoBehaviour
{
    public void OnPlayPressed()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1.0f;
    }


    public void OnExitPressed()
    {
        Application.Quit();
    }

}
