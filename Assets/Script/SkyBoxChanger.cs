using UnityEngine;

public class SkyBoxChanger : MonoBehaviour
{
    public Material[] skyboxes;

    // Call this with the index of the skybox you want to switch to
    public void SetSkybox(int index)
    {
        if (index >= 0 && index < skyboxes.Length)
        {
            RenderSettings.skybox = skyboxes[index];
            DynamicGI.UpdateEnvironment(); // refresh lighting/reflections
            Debug.Log("SkyChanged");

            PlayerPrefs.SetInt("SelectedSkybox", index); // remember choice
            PlayerPrefs.Save();
        }
    }
   
}
