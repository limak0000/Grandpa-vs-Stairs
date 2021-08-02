using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
       
    public void Shop()
    {
        //AdManager.instance.DestroyBanner();
        Time.timeScale = 1;
        ScoreCount.Score = 0;
        SceneManager.LoadScene(2);
    }

    public void Play()
    {
        //AdManager.instance.DestroyBanner();
        Time.timeScale = 1;
        ScoreCount.Score = 0;
        SceneManager.LoadScene(1);
    }


    // Use this for initialization
    void Start () {
        //AdManager.instance.RequestBanner();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
