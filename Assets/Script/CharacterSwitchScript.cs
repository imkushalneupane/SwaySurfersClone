using UnityEngine;

public class CharacterSwitchScript : MonoBehaviour
{
    [SerializeField]  
    private GameObject[] _characters;  //array of Playable characters

    private int _currentIndex;

    private void Start()
    {
       _currentIndex =  PlayerPrefs.GetInt("SelectedCharacter",0);
        CharacterSwitch(_currentIndex); // Selecting the Previously selected character when game starts
    }

    private void CharacterSwitch(int index)
    {
        for(int i = 0; i < _characters.Length; i++)
        {
            _characters[i].SetActive(false);    //Disabling all the Characters first!!
        }
        _characters[index].SetActive(true);  //then enabline the chosen one!!
    }

}
