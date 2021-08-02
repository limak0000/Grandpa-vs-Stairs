using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour {
    public static Text CoinsCount;
    public static int TotalCoins;
    public static int rewardedNum;

    // Use this for initialization
    void Start () {
        if(PlayerPrefs.GetInt("CoinValue", 0) == 0) { PlayerPrefs.SetInt("CoinValue", 10); }
        TotalCoins = PlayerPrefs.GetInt("Coins", 0);
        CoinsCount = GetComponent<Text>();
    }

    public static void UpdateCoins()
    {
        TotalCoins += PlayerPrefs.GetInt("CoinValue", 0);
            PlayerPrefs.SetInt("Coins", TotalCoins);
    }
    
    public static void Reward()
    {
        if(rewardedNum == 0)
        {
            GameController.instance.RewardedButton.SetActive(false);
            GameController.instance.basicCoin = GameController.CoinNumPerGame * 3;
            GameController.instance.BonusCoin.text = GameController.instance.basicCoin.ToString();
            CoinCount.TotalCoins += GameController.instance.basicCoin;
            PlayerPrefs.SetInt("Coins", CoinCount.TotalCoins);

            rewardedNum++;
            GameController.instance.BonusCoinSet.SetActive(true);
            Debug.Log("GOOD BOY");
        }
    }

    // Update is called once per frame
    void Update () {
        CoinsCount.text = PlayerPrefs.GetInt("Coins", 0).ToString();
        //Debug.Log(ScoreCount.Score);
    }
}
