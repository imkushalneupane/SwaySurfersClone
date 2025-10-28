using System;
using TMPro;
using UnityEngine;

public class CharacterPreviewScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _characters; //array of Playable Characters

    private int _currentIndex;

    [SerializeField]
    private GameObject _leftArrow;
    [SerializeField]
    private GameObject _rightArrow;

    private void Start()
    {
        Time.timeScale =  1;  //resuming the timescale for preview animations

        _currentIndex = PlayerPrefs.GetInt("SelectedCharacter",1);   //checking character from previeviously saved 
        ShowCharacter(_currentIndex);
        LeftCheck();  //to prevent arrow on left most character preview
        RightCheck();  // to prevent arrow on rightmost character preview
    }

    private void ShowCharacter(int index)
    {
        for(int i = 0; i < _characters.Length; i++)  //disabling all else first
        {
            _characters[i].SetActive(false);
        }
        _characters[index].SetActive(true);  //then enable the chosen one
    }

    public void OnLeftPressed()
    {
        if(_currentIndex >= 0)
        {
            _currentIndex --;
            ShowCharacter(_currentIndex);
        }
        LeftCheck();
        _rightArrow.SetActive(true);
    }
    public void OnRightPressed()
    {
        if (_currentIndex <= _characters.Length - 1)
        {
            _currentIndex++;
            ShowCharacter(_currentIndex);
        }
        RightCheck();
        _leftArrow.SetActive(true);
    }

    public void OnSelectPressed()   //Saving the preferences of the Player
    {
        PlayerPrefs.SetInt("SelectedCharacter",_currentIndex);
        PlayerPrefs.Save();   
    }


    private void LeftCheck()
    {
        if (_currentIndex <= 0)
        {
            _leftArrow.gameObject.SetActive(false);
        }
    }
    private void RightCheck()
    {
        if (_currentIndex >= _characters.Length - 1)
        {
            _rightArrow.gameObject.SetActive(false);
        }
    }
}
