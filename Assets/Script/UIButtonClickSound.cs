using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonClickSound : MonoBehaviour
{
    private AudioSource uiAudioSource;

    void Start()
    {
        // Faster, modern API
        Canvas canvas = FindFirstObjectByType<Canvas>();
        if (canvas != null)
            uiAudioSource = canvas.GetComponent<AudioSource>();

        GetComponent<Button>().onClick.AddListener(PlayClickSound);
    }

    void PlayClickSound()
    {
        if (uiAudioSource != null && uiAudioSource.clip != null)
            uiAudioSource.PlayOneShot(uiAudioSource.clip);
    }
}
