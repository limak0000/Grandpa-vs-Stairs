using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {

    Image HPbar;
    //float maxHP = 100f;
    public static float hp;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetFloat("MaxHP", 0) == 0) { PlayerPrefs.SetFloat("MaxHP", 100f); }
        HPbar = GetComponent<Image>();
        hp = PlayerPrefs.GetFloat("MaxHP", 0);
	}
	
	// Update is called once per frame
	void Update () {
        HPbar.fillAmount = hp / PlayerPrefs.GetFloat("MaxHP", 0);
	}
}
