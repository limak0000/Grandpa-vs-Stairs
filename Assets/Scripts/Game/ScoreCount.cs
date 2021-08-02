using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour {

	public static Text ScoreText;
	public static int Score;
    public static int checkHighScore;


    // Use this for initialization
    void Start () {
		ScoreText = GetComponent<Text> ();
        ScoreText.text = Score.ToString() + " \nStair";
        checkHighScore = PlayerPrefs.GetInt("HighScore", 0);
    }
	
	// Update is called once per frame
	public static void UpdateScore () {
        if (HP.hp > 0)
        {
            Score++;
            if (Score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", Score);
                HighScore.highScore.text = Score.ToString();
            }
            if (Score <= 1) { ScoreText.text = Score.ToString() + " \nStair"; }
            else { ScoreText.text = Score.ToString() + " \nStairs"; }
        }
    }

    public static void UpdateRealScore()
    {
        if (HP.hp > 0)
        {
            Score--;
        }

    }
}
