using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananaWork : MonoBehaviour {

    public static bool queriesHitTriggers = true;
    Rigidbody2D banana;

    void Start()
    {
        if(PlayerPrefs.GetInt("BananaValue", 0) == 0) { PlayerPrefs.SetInt("BananaValue", 1); }
        banana = GetComponent<Rigidbody2D>();
    }
    void OnMouseDown()
    {
        if (GameController.pauseState == 0)
        {
            banana.AddForce(Vector2.up * 6000, ForceMode2D.Impulse);
            banana.AddForce(Vector2.right * 2000, ForceMode2D.Impulse);
            banana.angularVelocity = -5000;
            GetComponent<BoxCollider2D>().enabled = false;
            CoinCount.TotalCoins += PlayerPrefs.GetInt("BananaValue", 0);
            GameController.CoinNumPerGame += PlayerPrefs.GetInt("BananaValue", 0);
            PlayerPrefs.SetInt("Coins", CoinCount.TotalCoins);
            JumpingTextManager.Instance.CreateCoinText(transform.position, "+" + PlayerPrefs.GetInt("BananaValue", 0) + "G", Color.yellow);
            Destroy(gameObject, 5);
        }
    }

  /*
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left click, casting ray.");
            CastRay();
        }
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            Debug.Log(hit.collider.name);
            if(hit.collider.tag == "bananaArea")
            {
                banana.AddForce(Vector2.up * 400, ForceMode2D.Impulse);
                banana.AddForce(Vector2.right * 300, ForceMode2D.Impulse);
                banana.angularVelocity = -3000;
            }
        }
    }
    */
}
