using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllerScript : MonoBehaviour
{
    public void OnPlayPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnExitPressed()
    {
        Application.Quit();
    }

}
