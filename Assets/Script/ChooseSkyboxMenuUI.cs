using UnityEngine;
using UnityEngine.UI;

public class ChooseSkyboxMenuUI : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _SkyboxImages; //array of skybox images
    [SerializeField]
    private Image _previewImage;  //the preview image to be shown on UI

    private int _currentIndex;

    [SerializeField]
    private Button _leftArrow;
    [SerializeField]
    private Button _rightArrow;

    [SerializeField]
    private SkyBoxChanger _skyBoxChanger;

    private void Start()
    {
        _currentIndex = PlayerPrefs.GetInt("SelectedSkybox",0);
        ShowPreview(_currentIndex);     //loads the image on first launch

        LeftCheck();
        RightCheck();
    }

    public void ShowPreview(int index)
    {
        if(index < 0 || index >= _SkyboxImages.Length)
            return;

        _currentIndex = index;

        _previewImage.sprite = _SkyboxImages[index];
    }

    public void OnLeftPress()
    {
        if (_currentIndex >= 0)
        { 

        _currentIndex--;
        ShowPreview(_currentIndex);

        LeftCheck(); //hides arrow when on leftmost panel
            _rightArrow.gameObject.SetActive(true);
        }
    }
    public void OnRightPressed()
    {
        if( _currentIndex <= _SkyboxImages.Length - 1)
        {    

        _currentIndex++;
        ShowPreview(_currentIndex);

        RightCheck();  //hides arrow when on rightmost panel
            _leftArrow.gameObject.SetActive(true);
        }
    }

    public void OnSelectPressed()
    {
        _skyBoxChanger.SetSkybox(_currentIndex);
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
        if (_currentIndex >= _SkyboxImages.Length - 1)  
        {
            _rightArrow.gameObject.SetActive(false);
        }
    }

}
