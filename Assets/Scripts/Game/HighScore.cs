using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public static Text highScore;
    
    public GameObject NewBestText;

    // Use this for initialization
    void Start () {
        
        highScore = GetComponent<Text>();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteAll();
            highScore.text = "0";
            
        }

        if (ScoreCount.checkHighScore < ScoreCount.Score)
        {
            NewBestText.SetActive(true);
        }
    }
}
