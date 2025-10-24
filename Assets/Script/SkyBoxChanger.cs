using JetBrains.Annotations;
using UnityEngine;

public class SkyBoxChanger : MonoBehaviour
{
    public Material[] skyboxes;


    private void Start()
    {
        int index = PlayerPrefs.GetInt("SelectedSkybox",2);  //applying the skybox once!!
    }

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
