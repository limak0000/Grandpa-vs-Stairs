using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudWork : MonoBehaviour {
    int i;
    // Use this for initialization
    void Start () {
        i = Random.Range(0, 4);
        
            

    }
	
	// Update is called once per frame
	void Update () {
        switch (i)
        {
            case 0:
                transform.Translate(Vector2.left * 50f * Time.smoothDeltaTime);
                break;
            case 1:
                transform.Translate(Vector2.left * 100f * Time.smoothDeltaTime);
                break;
            case 2:
                transform.Translate(Vector2.left * 150f * Time.smoothDeltaTime);
                break;
            case 3:
                transform.Translate(Vector2.left * 200f * Time.smoothDeltaTime);
                break;
            case 4:
                transform.Translate(Vector2.left * 250f * Time.smoothDeltaTime);
                break;
        }
    }
}
