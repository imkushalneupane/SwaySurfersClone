using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialImage; 

    void Start()
    {
        // Check if the tutorial has already been shown
        if (PlayerPrefs.GetInt("TutorialShown", 0) == 0)
        {
           StartCoroutine(ShowTutorial());
        }
        else
        {
            tutorialImage.SetActive(false); // Hide if already seen
        }
    }

    IEnumerator ShowTutorial()
    {

        yield return new WaitForSeconds(.75f);
        tutorialImage.SetActive(true); // Show tutorial
        Time.timeScale = 0f;
    }

    
    public void CloseTutorial()
    {
        tutorialImage.SetActive(false);
        PlayerPrefs.SetInt("TutorialShown", 1); // Mark as shown
        PlayerPrefs.Save();
        Time.timeScale = 1f;
    }
}
