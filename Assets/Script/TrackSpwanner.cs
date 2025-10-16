using System.Collections.Generic;
using UnityEngine;

public class TrackSpwanner : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private GameObject _tracks;
    
    private int _tracksOnScreen = 1;
    
    private List <GameObject> _spawnnedTracks = new List<GameObject> ();

    private float spawnZ = 75f; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnInitial();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.position.z > spawnZ - 40)
        {
            SpawnPlatform();
            spawnZ += 75;
        }
        if (_spawnnedTracks.Count > 0 && _player.position.z > _spawnnedTracks[0].transform.position.z + 75)
        {
            DestroyTrack();
        }

    }
   
    void SpawnPlatform()
    {

        GameObject tk = Instantiate (_tracks, new Vector3((float)-3.67 ,0, spawnZ), Quaternion.identity);
        _spawnnedTracks.Add(tk);
        _tracksOnScreen++;

    }
    void DestroyTrack()
    {
        Destroy(_spawnnedTracks[0]);
        _spawnnedTracks.RemoveAt(0);
        _tracksOnScreen--;
    }

    void SpawnInitial()
    {
        GameObject InitialTrack = Instantiate(_tracks, new Vector3((float)-3.67, 0, 0), Quaternion.identity);
        _spawnnedTracks.Add(InitialTrack);
    }
    public void ResetTrack()
    {
        foreach(GameObject track in _spawnnedTracks)
        {
            Destroy(track);
        }
        _spawnnedTracks.Clear();
        _tracksOnScreen = 1;
        spawnZ = 75;
        SpawnInitial();

    }

}
