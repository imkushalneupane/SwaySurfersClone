using System.Collections.Generic;
using UnityEngine;

public class BackGroundSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private GameObject _background;

    private int _backgroundOnScreen = 1;

    private List<GameObject> _spawnnedBackground = new List<GameObject>();

    private float spawnZ = 85f;



    void Start()
    {
        SpawnInitial();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.position.z > spawnZ - 80)
        {
            SpawnPlatform();
            spawnZ += 87;
        }
        if (_spawnnedBackground.Count > 0 && _player.position.z > _spawnnedBackground[0].transform.position.z + 90)
        {
            DestroyTrack();
        }

    }

    void SpawnPlatform()
    {

        GameObject bg = Instantiate(_background, new Vector3((float)-15.3168, 0, spawnZ), Quaternion.identity);
        _spawnnedBackground.Add(bg);
        _backgroundOnScreen++;
        Debug.Log("Spawmed Background!");

    }
    void DestroyTrack()
    {
        Destroy(_spawnnedBackground[0]);
        _spawnnedBackground.RemoveAt(0);
        _backgroundOnScreen--;
        Debug.Log("Destroyed BG!!");
    }

    void SpawnInitial()
    {
        GameObject InitialTrack = Instantiate(_background, new Vector3((float)-15.3168, 0, 0), Quaternion.identity);
        _spawnnedBackground.Add(InitialTrack);
        Debug.Log("Initial BG spawned!!");
    }
    public void ResetTrack()
    {
        foreach (GameObject track in _spawnnedBackground)
        {
            Destroy(track);
        }
        _spawnnedBackground.Clear();
        _backgroundOnScreen = 1;
        spawnZ = 87;
        SpawnInitial();

    }

}
