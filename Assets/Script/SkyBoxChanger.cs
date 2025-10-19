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
        }
    }

    private void Update()
    {
        if (skyboxes != null)
        {
            if(Input.GetKey(KeyCode.Alpha0))
            {
                SetSkybox(0);
            }
            if (Input.GetKey(KeyCode.Alpha1))
            {
                SetSkybox(1);
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                SetSkybox(2);
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                SetSkybox(3);
            }

        }
    }
}
