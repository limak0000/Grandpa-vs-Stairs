using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {

    public GameObject HPnoBorke;
    public GameObject HPborke;
   
    private bool onCD;

    // Use this for initialization
    void Start () {
		if (PlayerPrefs.GetFloat("DMG", 0) == 0) { PlayerPrefs.SetFloat("DMG", 5f); }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Stair" && HP.hp > 0)
        {
            HP.hp -= PlayerPrefs.GetFloat("DMG", 0);
            if (!onCD)
            {
                StartCoroutine(CoolDownDamage());

                JumpingTextManager.Instance.CreateDmgText(transform.position, "-", Color.red);
            }
            HPnoBorke.SetActive(false);
            HPborke.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "passZone" && HP.hp != 0)
        {
            ScoreCount.UpdateRealScore();
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(HP.hp != 0)
        {
            HPnoBorke.SetActive(true);
            HPborke.SetActive(false);
        }

    }

    private IEnumerator CoolDownDamage()
    {
        onCD = true;
        yield return new WaitForSeconds(0.1f);
        onCD = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
