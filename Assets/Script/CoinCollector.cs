using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _coins = 0;
    private int _highest = 0;
    [SerializeField]
    private TextMeshProUGUI _coinText;
    [SerializeField]
    private TextMeshProUGUI _highestText;

    [Space]
    [SerializeField]
    private Player _player;
    [SerializeField]
    private float _speedPerCoin = 0.2f;
    [SerializeField]
    private float _maxSpeed = 5f;

    private void Start()
    {
        _highest = PlayerPrefs.GetInt("HighScore",0);  //loads saved highscore
        ShowHightest();
    }



    void OnTriggerEnter(Collider coinColl)
    {
        if (coinColl.gameObject.CompareTag("Coin"))
        {
            _coins ++;
            Debug.Log("coin");
            Destroy(coinColl.gameObject);
            ShowCoins();
            if (_speedPerCoin < _maxSpeed) //need to fix this!! player.currentspeed
            {
                _player.IncreaseSpeed(_speedPerCoin);
            }
           

            if (_coins > _highest)
            {
                _highest = _coins;
                ShowHightest();
                PlayerPrefs.SetInt("HighScore",_highest); //saves new highscore!!
                PlayerPrefs.Save(); //writes it on disk
            }
        }
    }

    public void ShowCoins()
    {
        _coinText.text = "" + _coins.ToString();
    }  
    public void ShowHightest()
    {
        _highestText.text = "" + _highest.ToString();
    }

    public void Replay()
    {
        _coins = 0;
        ShowCoins();

    }
    
}
