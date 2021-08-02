using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsWork : MonoBehaviour {

    Animator anim;
    Rigidbody2D coin;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        coin = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        if (GameController.pauseState == 0)
        {
            anim.SetInteger("State", 1);
            coin.AddForce(Vector2.down * 2000, ForceMode2D.Impulse);
            CoinCount.UpdateCoins();
            GameController.CoinNumPerGame += PlayerPrefs.GetInt("CoinValue", 0);
            JumpingTextManager.Instance.CreateCoinText(transform.position, "+" + PlayerPrefs.GetInt("CoinValue", 0).ToString() + "G", Color.yellow);
            GetComponent<BoxCollider2D>().enabled = false;
            Invoke("Leaving", 0.1f);
            Destroy(gameObject, 0.25f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && PlayerPrefs.GetInt("TouchingGold", 0) == 1)
        {
            anim.SetInteger("State", 1);
            coin.AddForce(Vector2.down * 2000, ForceMode2D.Impulse);
            CoinCount.UpdateCoins();
            GameController.CoinNumPerGame += PlayerPrefs.GetInt("CoinValue", 0);
            JumpingTextManager.Instance.CreateCoinText(transform.position, "+" + PlayerPrefs.GetInt("CoinValue", 0).ToString() + "G", Color.yellow);
            GetComponent<BoxCollider2D>().enabled = false;
            Invoke("Leaving", 0.1f);
            Destroy(gameObject, 0.25f);
        }
    }

    void Leaving()
    {
        coin.AddForce(Vector2.up * 10000, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update () {

    }
}
