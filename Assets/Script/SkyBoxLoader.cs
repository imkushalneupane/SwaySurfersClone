using UnityEngine;

public class GameSkyboxLoader : MonoBehaviour
{
    public Material[] skyboxes;

    void Awake()
    {
        int selected = PlayerPrefs.GetInt("SelectedSkybox", 0);
        if (selected >= 0 && selected < skyboxes.Length)
        {
            RenderSettings.skybox = skyboxes[selected];
            DynamicGI.UpdateEnvironment();
        }
    }
}
