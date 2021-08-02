using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour {

    [SerializeField]
    private Transform centerBG;

	
	// Update is called once per frame
	void Update () {
        if (transform.position.x >= centerBG.position.x + 3495f)
            centerBG.position = new Vector2(centerBG.position.x + 3495f, centerBG.position.y);
        else if (transform.position.x <= centerBG.position.x - 3495f)
            centerBG.position = new Vector2(centerBG.position.x - 3495f, centerBG.position.y);
    }
}
