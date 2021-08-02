using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPcount : MonoBehaviour {
    public static Text CurrentHpText;

    // Use this for initialization
    void Start () {
        CurrentHpText = GetComponent<Text>();
        CurrentHpText.text = HP.hp.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if(HP.hp>=0)
        {
            CurrentHpText.text = HP.hp.ToString();
        }
        else
        {
            CurrentHpText.text = "0";
        }
    }
}
