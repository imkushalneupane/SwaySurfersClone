using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameButtonClickSounds : MonoBehaviour
{
    private AudioSource clickAudio;
    private Button btn;

    void Awake()
    {
        btn = GetComponent<Button>();
        clickAudio = GetComponentInParent<AudioSource>();
    }

    void OnEnable()
    {
        btn.onClick.AddListener(PlayClickSound);
    }

    void OnDisable()
    {
        btn.onClick.RemoveListener(PlayClickSound);
    }

    void PlayClickSound()
    {
        if (clickAudio != null && clickAudio.clip != null)
        {
            // Play the clip immediately, independent of object lifetime
            clickAudio.PlayOneShot(clickAudio.clip);
        }
    }
}
