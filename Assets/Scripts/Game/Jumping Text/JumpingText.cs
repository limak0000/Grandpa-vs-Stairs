using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpingText : MonoBehaviour {

    private float speed;
    private Vector3 direction;
    private float fadeTime;
    public Image image;
    public AnimationClip anim;

	// Update is called once per frame
	void Update () {
        float translation = speed * Time.deltaTime;

        transform.Translate(direction * translation);
	}

    public void Initialize(float speed, Vector3 direction, float fadeTime)
    {
        this.speed = speed;
        this.direction = direction;
        this.fadeTime = fadeTime;

        //GetComponent<Animator>().SetTrigger("TextAnimation");

        StartCoroutine(TextAnimation());
    }

    private IEnumerator TextAnimation()
    {
        yield return new WaitForSeconds(anim.length*2f);

        StartCoroutine(Fadeout());
    }

    private IEnumerator Fadeout()
    {
        float startAlpha = GetComponent<Text>().color.a;
        float rate = 1.0f / fadeTime;
        float progress = 0.0f;

        while (progress < 1.0)
        {
            Color tmpColor = GetComponent<Text>().color;

            GetComponent<Text>().color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, Mathf.Lerp(startAlpha, 0, progress));
            image.color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, Mathf.Lerp(startAlpha, 0, progress));
            progress += rate * Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
    }
}
