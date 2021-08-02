using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpingTextManager : MonoBehaviour {

    private static JumpingTextManager instance;

    public GameObject textPrefabDmg;
    public GameObject textPrefabCoin;

    public RectTransform canvasTransform;

    public float speed;

    public Vector3 direction;

    public float fadeTime;

    public static JumpingTextManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<JumpingTextManager>();
            }
            return instance;
        }
    }

    public void CreateDmgText(Vector3 position, string text, Color color)
    {
        GameObject sct = (GameObject)Instantiate(textPrefabDmg, position, Quaternion.identity);

        sct.transform.SetParent(canvasTransform);
        sct.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        sct.GetComponent<JumpingText>().Initialize(speed, direction, fadeTime);
        sct.GetComponent<Text>().text = text;
        sct.GetComponent<Text>().color = color;
    }

    public void CreateCoinText(Vector3 position, string text, Color color)
    {
        GameObject sct = (GameObject)Instantiate(textPrefabCoin, position, Quaternion.identity);

        sct.transform.SetParent(canvasTransform);
        sct.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        sct.GetComponent<JumpingText>().Initialize(speed, direction, fadeTime);
        sct.GetComponent<Text>().text = text;
        sct.GetComponent<Text>().color = color;
    }
}
