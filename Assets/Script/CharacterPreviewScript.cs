using System;
using TMPro;
using UnityEngine;

public class CharacterPreviewScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _characters; //array of Playable Characters

    private int _currentIndex = 1;

    [SerializeField]
    private GameObject _leftArrow;
    [SerializeField]
    private GameObject _rightArrow;

    private void Start()
    {
        Time.timeScale =  1;
        ShowCharacter(_currentIndex);
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
