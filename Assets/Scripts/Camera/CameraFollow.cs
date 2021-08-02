using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform Grandpa;
	public Transform TP;
	public Transform BG;
    public Transform Warning;

    float XoffsetC, YoffsetC, Xoffseta;
    float BGoffsetX, BGoffsetY;
    float WarningX, WarningY;

    Vector3 pos;
    Vector3 BGpos;
    Vector3 WarningPos;

    // Use this for initialization
    void Start () {
		XoffsetC = transform.position.x - Grandpa.position.x;
		YoffsetC = transform.position.y - Grandpa.position.y;
		Xoffseta = TP.position.x - Grandpa.position.x;
        BGoffsetX = BG.position.x - Grandpa.position.x;
        BGoffsetY = BG.position.y - Grandpa.position.y;
        WarningX = Warning.position.x - Grandpa.position.x;
        WarningY = Warning.position.y - Grandpa.position.y;

        BGpos.z = 1;
    }
	
	// Update is called once per frame
	void Update () {
		pos = transform.position;
        BGpos = BG.position;
        BGoffsetX = BGoffsetX + 0; //useless
        pos.x = Grandpa.position.x + XoffsetC;
		pos.y = Grandpa.position.y + YoffsetC + 200;
		transform.position = pos;

        //pos.z = 1;

        BGpos.x = BG.position.x;
        BGpos.y = Grandpa.position.y + BGoffsetY;
        BG.position = BGpos;

        WarningPos.x = Grandpa.position.x + WarningX;
        WarningPos.y = Grandpa.position.y + WarningY;
        Warning.position = WarningPos;

        pos.x = Grandpa.position.x + Xoffseta;
		pos.y = -(Grandpa.position.x);
		TP.position = pos;
	}
}
