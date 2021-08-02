using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class GameController : MonoBehaviour {
	
	Rigidbody2D Grandpa;
    Animator anim;
    //public GameObject GyroControl;

    bool Jumping, Grounded, canDoubleJump;
    bool oldJump = true;
    bool upBanning, downBanning, leftBanning, rightBanning = false;
    bool Bananaing = false;
    private bool onCD;

    private bool gameOver = false;
    [SerializeField]
    private GameObject gameOverMenu;
    [SerializeField]
    private GameObject pauseMenu;
    public static int pauseState;
    public Text CoinPerGame;
    public static int CoinNumPerGame;

    [SerializeField]
    private GameObject Questions;
    
    public GameObject PauseButton;

    public GameObject RewardedButton;
    public GameObject BonusCoinSet;
    public Text BonusCoin;
    public int basicCoin = 0;

    public GameObject RedButton;
	public GameObject BlueButton;
	public GameObject YellowButton;
	public GameObject GreenButton;

    public GameObject up;
    public GameObject left;
    public GameObject right;
    public GameObject down;
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;

    public GameObject upB1, upB2, upB3, upB4, upB5, upB6, upB7, upB8, upB9, upB10;
    public GameObject leftB1, leftB2, leftB3, leftB4, leftB5, leftB6, leftB7, leftB8, leftB9, leftB10;
    public GameObject rightB1, rightB2, rightB3, rightB4, rightB5, rightB6, rightB7, rightB8, rightB9, rightB10;
    public GameObject downB1, downB2, downB3, downB4, downB5, downB6, downB7, downB8, downB9, downB10;

    public GameObject Warning, smallCloud;

    public Transform Button;

    Vector3 Bst; // = (-350f, -484f, 0f);
    Vector3 Bnd; // = (-190f, -484f, 0f);
    Vector3 Brd; // = (-30f, -484f, 0f);
    Vector3 Bth; // = (130f, -484f, 0f);

    private int Bpos;
    private int BposSetUp = 0;
    private int color;
	private int rotation = 0;
    private int worngCount = 0;
    private int hurt = 0;
    public static GameController instance;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(this); }
    }

    void Start () {
        Time.timeScale = 1f;
        anim = GetComponent<Animator>();
        Grandpa = GetComponent<Rigidbody2D> ();
        if(PlayerPrefs.GetInt("MaxWrongCount", 0) == 0) { PlayerPrefs.SetInt("MaxWrongCount", 10); }
        if(PlayerPrefs.GetFloat("Rate", 0) == 0) { PlayerPrefs.SetFloat("Rate", 1); }
        Setting();
        pauseState = 0;
        CoinNumPerGame = 0;
        basicCoin = 0;
        CoinCount.rewardedNum = 0;

        AdManager.instance.RequestInterstitial();
        AdManager.instance.RequestRewardBasedVideo();
    }

    void Setting()
    {
        Warning.SetActive(false);

        RedButton.SetActive(false);
        BlueButton.SetActive(false);
        YellowButton.SetActive(false);
        GreenButton.SetActive(false);

        RedButton.transform.Rotate(0, 0, -(rotation * 90));
        BlueButton.transform.Rotate(0, 0, -(rotation * 90));
        YellowButton.transform.Rotate(0, 0, -(rotation * 90));
        GreenButton.transform.Rotate(0, 0, -(rotation * 90));

        rotation = Random.Range(0, 4);

        RedButton.transform.Rotate(0, 0, rotation * 90);
        BlueButton.transform.Rotate(0, 0, rotation * 90);
        YellowButton.transform.Rotate(0, 0, rotation * 90);
        GreenButton.transform.Rotate(0, 0, rotation * 90);

        color = Random.Range(0, 4);
        switch (color)
        {
            case 0:
                RedButton.SetActive(true);
                break;
            case 1:
                BlueButton.SetActive(true);
                break;
            case 2:
                YellowButton.SetActive(true);
                break;
            case 3:
                GreenButton.SetActive(true);
                break;
        }
    }

    void GOOD()
    {
        if ((Grounded || canDoubleJump) && HP.hp > 0) 
        {
            Time.timeScale = 1; hurt = 0; Time.fixedDeltaTime = 0.02F;
            Warning.SetActive(false);
            Bananaing = false;
            Setting();
            Jump();
            ResetBpos();
        }
    }

    void ResetBpos()
    {
        if (BposSetUp == 0)
        {
            Bst = GameObject.FindGameObjectWithTag("leftButton").transform.position;
            Bnd = GameObject.FindGameObjectWithTag("downButton").transform.position;
            Brd = GameObject.FindGameObjectWithTag("rightButton").transform.position;
            Bth = GameObject.FindGameObjectWithTag("upButton").transform.position;
        }

        Bpos = Random.Range(0, 4);

        switch (Bpos)
        {
            case 0:
                up.transform.position = Bst;
                Bpos = Random.Range(0, 3);
                switch (Bpos)
                {
                    case 0:
                        down.transform.position = Bnd;
                        Bpos = Random.Range(0, 2);
                        if (Bpos == 0) { left.transform.position = Brd; right.transform.position = Bth; }
                        else { left.transform.position = Bth; right.transform.position = Brd; }
                        break;
                    case 1:
                        down.transform.position = Brd;
                        Bpos = Random.Range(0, 2);
                        if (Bpos == 0) { left.transform.position = Bnd; right.transform.position = Bth; }
                        else { left.transform.position = Bth; right.transform.position = Bnd; }
                        break;
                    case 2:
                        down.transform.position = Bth;
                        Bpos = Random.Range(0, 2);
                        if (Bpos == 0) { left.transform.position = Bnd; right.transform.position = Brd; }
                        else { left.transform.position = Brd; right.transform.position = Bnd; }
                        break;
                }
                break;
            case 1:
                up.transform.position = Bnd;
                Bpos = Random.Range(0, 3);
                switch (Bpos)
                {
                    case 0:
                        down.transform.position = Bst;
                        Bpos = Random.Range(0, 2);
                        if (Bpos == 0) { left.transform.position = Brd; right.transform.position = Bth; }
                        else { left.transform.position = Bth; right.transform.position = Brd; }
                        break;
                    case 1:
                        down.transform.position = Brd;
                        Bpos = Random.Range(0, 2);
                        if (Bpos == 0) { left.transform.position = Bst; right.transform.position = Bth; }
                        else { left.transform.position = Bth; right.transform.position = Bst; }
                        break;
                    case 2:
                        down.transform.position = Bth;
                        Bpos = Random.Range(0, 2);
                        if (Bpos == 0) { left.transform.position = Bst; right.transform.position = Brd; }
                        else { left.transform.position = Brd; right.transform.position = Bst; }
                        break;
                }
                break;
            case 2:
                up.transform.position = Brd;
                Bpos = Random.Range(0, 3);
                switch (Bpos)
                {
                    case 0:
                        down.transform.position = Bst;
                        Bpos = Random.Range(0, 2);
                        if (Bpos == 0) { left.transform.position = Bnd; right.transform.position = Bth; }
                        else { left.transform.position = Bth; right.transform.position = Bnd; }
                        break;
                    case 1:
                        down.transform.position = Bnd;
                        Bpos = Random.Range(0, 2);
                        if (Bpos == 0) { left.transform.position = Bst; right.transform.position = Bth; }
                        else { left.transform.position = Bth; right.transform.position = Bst; }
                        break;
                    case 2:
                        down.transform.position = Bth;
                        Bpos = Random.Range(0, 2);
                        if (Bpos == 0) { left.transform.position = Bnd; right.transform.position = Bst; }
                        else { left.transform.position = Bst; right.transform.position = Bnd; }
                        break;
                }
                break;
            case 3:
                up.transform.position = Bth;
                Bpos = Random.Range(0, 3);
                switch (Bpos)
                {
                    case 0:
                        down.transform.position = Bst;
                        Bpos = Random.Range(0, 2);
                        if (Bpos == 0) { left.transform.position = Brd; right.transform.position = Bnd; }
                        else { left.transform.position = Bnd; right.transform.position = Brd; }
                        break;
                    case 1:
                        down.transform.position = Brd;
                        Bpos = Random.Range(0, 2);
                        if (Bpos == 0) { left.transform.position = Bnd; right.transform.position = Bst; }
                        else { left.transform.position = Bst; right.transform.position = Bnd; }
                        break;
                    case 2:
                        down.transform.position = Bnd;
                        Bpos = Random.Range(0, 2);
                        if (Bpos == 0) { left.transform.position = Bst; right.transform.position = Brd; }
                        else { left.transform.position = Brd; right.transform.position = Bst; }
                        break;
                }
                break;
        }
    }

	public void UP() {

        if (rotation == 0) { GOOD(); } 

		else
        {
            Debug.Log ("BAD");
            upBanning = true;
            if (worngCount < PlayerPrefs.GetInt("MaxWrongCount", 0)) { worngCount++; }
            switch (worngCount)
            {
                case 10: upB10.SetActive(true); break;
                case 9: upB9.SetActive(true); break;
                case 8: upB8.SetActive(true); break;
                case 7: upB7.SetActive(true); break;
                case 6: upB6.SetActive(true); break;
                case 5: upB5.SetActive(true); break;
                case 4: upB4.SetActive(true); break;
                case 3: upB3.SetActive(true); break;
                case 2: upB2.SetActive(true); break;
                case 1: upB1.SetActive(true); break;
            }
        }

	}

    public void upBan10() { upB10.SetActive(false); upB9.SetActive(true); }
    public void upBan9() { upB9.SetActive(false); upB8.SetActive(true); }
    public void upBan8() { upB8.SetActive(false); upB7.SetActive(true); }
    public void upBan7() { upB7.SetActive(false); upB6.SetActive(true); }
    public void upBan6() { upB6.SetActive(false); upB5.SetActive(true); }
    public void upBan5() { upB5.SetActive(false); upB4.SetActive(true); }
    public void upBan4() { upB4.SetActive(false); upB3.SetActive(true); }
    public void upBan3() { upB3.SetActive(false); upB2.SetActive(true); }
    public void upBan2() { upB2.SetActive(false); upB1.SetActive(true); }
    public void upBan1() { upB1.SetActive(false); upBanning = false; }

    public void DOWN() {
		if (rotation == 2) { GOOD(); } 

		else
        {
            Debug.Log("BAD");
            downBanning = true;
            if (worngCount < PlayerPrefs.GetInt("MaxWrongCount", 0)) { worngCount++; }
            switch (worngCount)
            {
                case 10: downB10.SetActive(true); break;
                case 9: downB9.SetActive(true); break;
                case 8: downB8.SetActive(true); break;
                case 7: downB7.SetActive(true); break;
                case 6: downB6.SetActive(true); break;
                case 5: downB5.SetActive(true); break;
                case 4: downB4.SetActive(true); break;
                case 3: downB3.SetActive(true); break;
                case 2: downB2.SetActive(true); break;
                case 1: downB1.SetActive(true); break;
            }
        }
    }

    public void downBan10() { downB10.SetActive(false); downB9.SetActive(true); }
    public void downBan9() { downB9.SetActive(false); downB8.SetActive(true); }
    public void downBan8() { downB8.SetActive(false); downB7.SetActive(true); }
    public void downBan7() { downB7.SetActive(false); downB6.SetActive(true); }
    public void downBan6() { downB6.SetActive(false); downB5.SetActive(true); }
    public void downBan5() { downB5.SetActive(false); downB4.SetActive(true); }
    public void downBan4() { downB4.SetActive(false); downB3.SetActive(true); }
    public void downBan3() { downB3.SetActive(false); downB2.SetActive(true); }
    public void downBan2() { downB2.SetActive(false); downB1.SetActive(true); }
    public void downBan1() { downB1.SetActive(false); downBanning = false; }

    public void RIGHT() {
		if (rotation == 3) { GOOD(); }

        else
        {
            Debug.Log("BAD");
            rightBanning = true;
            if (worngCount < PlayerPrefs.GetInt("MaxWrongCount", 0)) { worngCount++; }
            switch (worngCount)
            {
                case 10: rightB10.SetActive(true); break;
                case 9: rightB9.SetActive(true); break;
                case 8: rightB8.SetActive(true); break;
                case 7: rightB7.SetActive(true); break;
                case 6: rightB6.SetActive(true); break;
                case 5: rightB5.SetActive(true); break;
                case 4: rightB4.SetActive(true); break;
                case 3: rightB3.SetActive(true); break;
                case 2: rightB2.SetActive(true); break;
                case 1: rightB1.SetActive(true); break;
            }
        }
    }

    public void rightBan10() { rightB10.SetActive(false); rightB9.SetActive(true); }
    public void rightBan9() { rightB9.SetActive(false); rightB8.SetActive(true); }
    public void rightBan8() { rightB8.SetActive(false); rightB7.SetActive(true); }
    public void rightBan7() { rightB7.SetActive(false); rightB6.SetActive(true); }
    public void rightBan6() { rightB6.SetActive(false); rightB5.SetActive(true); }
    public void rightBan5() { rightB5.SetActive(false); rightB4.SetActive(true); }
    public void rightBan4() { rightB4.SetActive(false); rightB3.SetActive(true); }
    public void rightBan3() { rightB3.SetActive(false); rightB2.SetActive(true); }
    public void rightBan2() { rightB2.SetActive(false); rightB1.SetActive(true); }
    public void rightBan1() { rightB1.SetActive(false); rightBanning = false; }

    public void LEFT() {
		if (rotation == 1) { GOOD(); }

        else
        {
            Debug.Log("BAD");
            leftBanning = true;
            if (worngCount < PlayerPrefs.GetInt("MaxWrongCount", 0)) { worngCount++; }
            switch (worngCount)
            {
                case 10: leftB10.SetActive(true); break;
                case 9: leftB9.SetActive(true); break;
                case 8: leftB8.SetActive(true); break;
                case 7: leftB7.SetActive(true); break;
                case 6: leftB6.SetActive(true); break;
                case 5: leftB5.SetActive(true); break;
                case 4: leftB4.SetActive(true); break;
                case 3: leftB3.SetActive(true); break;
                case 2: leftB2.SetActive(true); break;
                case 1: leftB1.SetActive(true); break;
            }
        }
    }

    public void leftBan10() { leftB10.SetActive(false); leftB9.SetActive(true); }
    public void leftBan9() { leftB9.SetActive(false); leftB8.SetActive(true); }
    public void leftBan8() { leftB8.SetActive(false); leftB7.SetActive(true); }
    public void leftBan7() { leftB7.SetActive(false); leftB6.SetActive(true); }
    public void leftBan6() { leftB6.SetActive(false); leftB5.SetActive(true); }
    public void leftBan5() { leftB5.SetActive(false); leftB4.SetActive(true); }
    public void leftBan4() { leftB4.SetActive(false); leftB3.SetActive(true); }
    public void leftBan3() { leftB3.SetActive(false); leftB2.SetActive(true); }
    public void leftBan2() { leftB2.SetActive(false); leftB1.SetActive(true); }
    public void leftBan1() { leftB1.SetActive(false); leftBanning = false; }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "passZone" && HP.hp > 0)
        {
            ScoreCount.UpdateScore();
            //Destroy(gameObject);
        }

        if (col.tag == "Cloud" && HP.hp > 0)
        {
            Warning.SetActive(true);
            Bananaing = true;
            Instantiate(smallCloud, transform.position, Quaternion.identity);
        }
        
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.tag == "Stair" && oldJump || other.gameObject.tag == "Start")
        {
            Grounded = true;
            Jumping = false;
            canDoubleJump = false;
            if (PlayerPrefs.GetInt("SlowMoNum", 0) == 1 && other.gameObject.tag != "Start" && hurt == 0) { Time.timeScale = 0.3f; Time.fixedDeltaTime = 0.02F * Time.timeScale; }
            anim.SetInteger("State", 0);
            //Button.position = new Vector3(961, 1276, 0);
        }

        if (other.gameObject.tag == "banana")
        {
            Grounded = true;
            Jumping = false;
            canDoubleJump = false;
            anim.SetInteger("State", 0);
            Grandpa.angularVelocity = -3000;
            //Grandpa.velocity = Grandpa.velocity * 0.0f;
            Grandpa.AddForce(Vector2.up * 600, ForceMode2D.Impulse);
            Grandpa.AddForce(Vector2.right * 80, ForceMode2D.Impulse);
            if (upBanning == false) { upB1.SetActive(true); upBanning = true; }
            if (leftBanning == false) { leftB1.SetActive(true); leftBanning = true; }
            if (downBanning == false) { downB1.SetActive(true); downBanning = true; }
            if (rightBanning == false) { rightB1.SetActive(true); rightBanning = true; }
            Warning.SetActive(true);
            Invoke("BananaTF", 0.25f);
        }

        if (Bananaing && !onCD && HP.hp > 0)
        {
            StartCoroutine(CoolDownDamage());
            switch (PlayerPrefs.GetInt("LanguageCode"))
            {
                case 0:
                    JumpingTextManager.Instance.CreateDmgText(transform.position, "Crit!", Color.red);
                    break;
                case 1:
                    JumpingTextManager.Instance.CreateDmgText(transform.position, "暴擊!", Color.red);
                    break;
                case 2:
                    JumpingTextManager.Instance.CreateDmgText(transform.position, "クリティカル!", Color.red);
                    break;
                case 3:
                    JumpingTextManager.Instance.CreateDmgText(transform.position, "भारी मार!", Color.red);
                    break;
                case 4:
                    JumpingTextManager.Instance.CreateDmgText(transform.position, "크리티컬!", Color.red);
                    break;
                case 5:
                    JumpingTextManager.Instance.CreateDmgText(transform.position, "Crit!", Color.red);
                    break;
                case 6:
                    JumpingTextManager.Instance.CreateDmgText(transform.position, "Kritisch!", Color.red);
                    break;
                case 7:
                    JumpingTextManager.Instance.CreateDmgText(transform.position, "Crit!", Color.red);
                    break;
                case 8:
                    JumpingTextManager.Instance.CreateDmgText(transform.position, "Крит!", Color.red);
                    break;
                case 9:
                    JumpingTextManager.Instance.CreateDmgText(transform.position, "คริติคอล!", Color.red);
                    break;
            }
            HP.hp -= PlayerPrefs.GetFloat("MaxHP", 0) * PlayerPrefs.GetFloat("Rate", 0);
        }
    }

    void Jump()
    {
        if (Grounded)
        {
            Grounded = false;
            Jumping = true;
            if (PlayerPrefs.GetInt("DoubleJumpNum", 0) != 0) {canDoubleJump = true;}
            
            anim.SetInteger("State", 1);
            GetComponent<Transform>().transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Grandpa.velocity = Grandpa.velocity*0.0f;//Vector3.zero;
            Grandpa.angularVelocity = 0;
            Grandpa.transform.RotateAround(Vector3.zero, Vector3.zero, 0);
            Grandpa.AddForce(Vector2.up * 400, ForceMode2D.Impulse);
            if (PlayerPrefs.GetInt("JumpForce", 0) == 0)
            { Grandpa.AddForce(Vector2.right * 300, ForceMode2D.Impulse); }
            else
            { Grandpa.AddForce(Vector2.right * (300 + PlayerPrefs.GetInt("JumpForce", 0)), ForceMode2D.Impulse); }
            oldJump = false;
            Invoke("JumpAge", 0.25f);
            //Button.position = new Vector3(961, 1276 - 3000, 1);
        }
        else
        {
            if (Jumping && canDoubleJump)
            {
                anim.SetInteger("State", 4);
                GetComponent<Transform>().transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Grandpa.velocity = Grandpa.velocity * 0.0f;//Vector3.zero;
                Grandpa.angularVelocity = 0;
                Grandpa.transform.RotateAround(Vector3.zero, Vector3.zero, 0);
                Grandpa.AddForce(Vector2.up * 400, ForceMode2D.Impulse);
                Grandpa.AddForce(Vector2.right * 300, ForceMode2D.Impulse); 
                canDoubleJump = false;
            }
        }
    }

    void BananaTF()
    {
        Bananaing = true;
    }

    void JumpAge()
    {
        oldJump = true;
    }

    public void GameOver()
    {
        if (!gameOver) { gameOver = true; }
        gameOverMenu.SetActive(true);
        PauseButton.SetActive(false);
        CoinPerGame.text = CoinNumPerGame.ToString();
        Questions.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Questions.SetActive(false);
        pauseState += 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Questions.SetActive(true);
        pauseState -= 1;
    }

    public void BackHome()
    {
        AdManager.instance.ShowInterstitial();
        Time.timeScale = 1;
        ScoreCount.Score = 0;
        SceneManager.LoadScene(0);
        pauseState -= 1;
    }

    public void Restart()
    {
        AdManager.instance.ShowInterstitial();
        Time.timeScale = 1;
        ScoreCount.Score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pauseState -= 1;
    }

    public void GoToShop()
    {
        AdManager.instance.ShowInterstitial();
        
        Time.timeScale = 1;
        ScoreCount.Score = 0;
        SceneManager.LoadScene(2);
    }

    private IEnumerator CoolDownDamage()
    {
        onCD = true;
        yield return new WaitForSeconds(0.25f);
        onCD = false;
    }

    void Update()
    {
        if (Jumping)
        {
            block1.SetActive(true);
            block2.SetActive(true);
            block3.SetActive(true);
            block4.SetActive(true);
        }

        if (Grounded || canDoubleJump)
        {
            block1.SetActive(false);
            block2.SetActive(false);
            block3.SetActive(false);
            block4.SetActive(false);
        }

        if (Grounded && Grandpa.transform.rotation.eulerAngles.z > 220 && Grandpa.transform.rotation.eulerAngles.z < 320)
        { anim.SetInteger("State", 5); Time.timeScale = 1; hurt = 1; Time.fixedDeltaTime = 0.02F; }
        if(Grounded && Grandpa.transform.rotation.eulerAngles.z < 220) { anim.SetInteger("State", 6); }

        if (HP.hp <= 0)
        {
            anim.SetInteger("State", 3);
            GetComponent<Transform>().transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            Grandpa.velocity = Grandpa.velocity * 0.0f;//Vector3.zero;
            Grandpa.angularVelocity = 0;
            Grandpa.transform.RotateAround(Vector3.zero, Vector3.zero, 0);
            ScoreCount.ScoreText.text = ScoreCount.Score.ToString() + " \nStairs";

            Invoke("GameOver", 1);
        }
        //Debug.Log(Grandpa.velocity);
        //Debug.Log(Grandpa.transform.rotation.eulerAngles.z);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpingTextManager.Instance.CreateDmgText(transform.position, "คริติคอล!", Color.red);
            //Debug.Log(Grandpa.transform.rotation.eulerAngles.z);
        }
    }
}
