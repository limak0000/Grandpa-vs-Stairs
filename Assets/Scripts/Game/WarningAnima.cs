using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningAnima : MonoBehaviour {

    public float scrollingSpeed = 0.5f;
    Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(Time.time * scrollingSpeed, 0);
        rend.material.mainTextureOffset = offset;

    }
}
