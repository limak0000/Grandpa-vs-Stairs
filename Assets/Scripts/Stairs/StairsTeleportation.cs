using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsTeleportation : MonoBehaviour {

    public GameObject Stair;
    public GameObject banana;
    public GameObject coin;

    public GameObject cloud_0;
    public GameObject cloud_1;
    public GameObject cloud_2;
    public GameObject cloud_3;
    public GameObject cloud_4;
    public GameObject cloud_5;
    public GameObject cloud_6;
    public GameObject cloud_7;
    public GameObject cloud_8;
    public GameObject cloud_9;
    public GameObject cloud_10;
    public GameObject cloud_11;

    Vector3 pos;
    int spawnChance;
    int cloudChance;
    int cloudPos;

    void OnTriggerEnter2D (Collider2D col) {
		if (pos.x == 0) {
			pos.x = 2025+200*3;
			pos.y = -740-110*3;
			pos.z = 1;
		}
		Destroy (col.transform.gameObject, 1);
        if (col.tag == "Stair" || col.tag == "Start")
        {
            spawn();
            spawnChance = Random.Range(0, 99);
            if (spawnChance < 10)
            {
                Instantiate(banana, new Vector3(pos.x, pos.y+500, 1), Quaternion.identity);
            }
            else if (spawnChance < 15 + PlayerPrefs.GetInt("CoinChance", 0))
            {
                Instantiate(coin, new Vector3(pos.x, pos.y + 520, 1), Quaternion.identity);
            }
            spawnCloud();

        }
    }

    void spawnCloud()
    {
        cloudChance = Random.Range(0, 40);
        cloudPos = Random.Range(2800, 3300);
        switch (cloudChance)
        {
            case 0:
                Instantiate(cloud_1, new Vector3(pos.x + 500, pos.y + cloudPos, 1), Quaternion.identity);
                break;
            case 1:
                Instantiate(cloud_2, new Vector3(pos.x + 500, pos.y + cloudPos, 1), Quaternion.identity);
                break;
            case 2:
                Instantiate(cloud_3, new Vector3(pos.x + 500, pos.y + cloudPos, 1), Quaternion.identity);
                break;
            case 3:
                Instantiate(cloud_4, new Vector3(pos.x + 500, pos.y + cloudPos, 1), Quaternion.identity);
                break;
            case 4:
                Instantiate(cloud_5, new Vector3(pos.x + 500, pos.y + cloudPos, 1), Quaternion.identity);
                break;
            case 5:
                Instantiate(cloud_6, new Vector3(pos.x + 500, pos.y + cloudPos, 1), Quaternion.identity);
                break;
            case 6:
                Instantiate(cloud_7, new Vector3(pos.x + 500, pos.y + cloudPos, 1), Quaternion.identity);
                break;
            case 7:
                Instantiate(cloud_8, new Vector3(pos.x + 500, pos.y + cloudPos, 1), Quaternion.identity);
                break;
            case 8:
                Instantiate(cloud_9, new Vector3(pos.x + 500, pos.y + cloudPos, 1), Quaternion.identity);
                break;
            case 9:
                Instantiate(cloud_10, new Vector3(pos.x + 500, pos.y + cloudPos, 1), Quaternion.identity);
                break;
            case 10:
                Instantiate(cloud_11, new Vector3(pos.x + 500, pos.y + cloudPos, 1), Quaternion.identity);
                break;
            case 11:
                Instantiate(cloud_0, new Vector3(pos.x + 500, pos.y + cloudPos, 1), Quaternion.identity);
                break;
        }
        //if(cloudChance < 11) { spawnCloud(); }
    }

	void spawn(){
		pos.x += 200;
		pos.y -= 110;
		Instantiate (Stair, pos, Quaternion.identity);
	}

}
