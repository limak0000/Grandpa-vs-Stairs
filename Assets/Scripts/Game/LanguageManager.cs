using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LanguageManager : MonoBehaviour {

    public GameObject Meun;
    [SerializeField]
    private GameObject settingMenu;
    public Text Setting;
    public Text Pause;
    public Text Language;
    public Text HighScore;
    public Text NewBest;
    public Text Stairs;
    public TextMesh warning;

    public int ScenNum;

    // Use this for initialization
    void Start () {
        CheckCode();
    }
	
    public void ShowUpMeun()
    {
        Meun.SetActive(true);
        settingMenu.SetActive(false);
    }

    public void SettingUI()
    {
        settingMenu.SetActive(true);
    }

    public void CloseSettungUI()
    {
        settingMenu.SetActive(false);
    }

    public void English()
    {
        LanguageSetting(0);
    } //0

    public void Chinese()
    {
        LanguageSetting(1);
    } //1

    public void Japan()
    {
        LanguageSetting(2);
    } //2

    public void Hindi()
    {
        LanguageSetting(3);
    } //3

    public void Korean()
    {
        LanguageSetting(4);
    } //4

    public void French()
    {
        LanguageSetting(5);
    } //5

    public void German()
    {
        LanguageSetting(6);
    } //6

    public void Italian()
    {
        LanguageSetting(7);
    } //7

    public void Russian()
    {
        LanguageSetting(8);
    } //8

    public void Thai()
    {
        LanguageSetting(9);
    } //9

    void LanguageSetting(int num)
    {
        PlayerPrefs.SetInt("LanguageCode", num);
        Meun.SetActive(false);
        CheckCode();
        if (ScenNum == 2) { AdManager.instance.DestroyBanner(); SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    }

    public void CheckCode()
    {
        switch (PlayerPrefs.GetInt("LanguageCode", 0))
        {
            case 0:
                ChangeText(" Settings", "  Pause", "  Language", "HIGH SCORE:", "Stairs", "New Best!", "Fall Hazard !");
                break;
            case 1:
                ChangeText("      設定", "   暫停", "      語言", "最高紀錄:", "級樓梯", "   新的最佳！", "當心墜落!");
                break;
            case 2:
                ChangeText("      設定", "一時停止", "      言語", "ハイスコア:", "階段", "   新しい最高！", "転倒危険!");
                break;
            case 3:
                ChangeText("   सेट करें", " ठहराव", "      भाषा", "उच्चतम रिकॉर्ड:", "मंजिला सीढ़ी", "नया सर्वश्रेष्ठ！", "गिरने का खतरा !");
                break;
            case 4:
                ChangeText("     설정 ", "   중지", "      언어 ", "높은 점수:", "층 계단", "새로운 베스트！", "가을 위험!");
                break;
            case 5:
                ChangeText("Paramètres", "  Pause", "  La langue", "SCORE ÉLEVÉ:", "Escaliers", "New Best!", "Risque de chute !");
                break;
            case 6:
                ChangeText("Einstellungen", "  Pause", "    Sprache", "HIGHSCORE:", "Treppe", "Neue beste!", "Absturzgefahr !");
                break;
            case 7:
                ChangeText("impostazioni", "  Pausa", " linguaggio", "PUNTEGGIO ALTO:", "Passi", "New Best!", "Fall Hazard !");
                break;
            case 8:
                ChangeText("Настройки", " Пауза", "     Язык", "РЕКОРД:", "лестниц", "Новый Бест！", "Падение опасности ! ");
                break;
            case 9:
                ChangeText("  การตั้งค่า", "     หยุด", "      ภาษา", "คะแนนสูง", "บันได", "  บันทึกใหม่！", "ตกอันตราย !");
                break;
        }
    }

    void ChangeText(string set, string pau, string lan, string hig, string sta, string newbest, string war)
    {
        Setting.text = set;
        Pause.text = pau;
        Language.text = lan;
        HighScore.text = hig;
        Stairs.text = sta;
        NewBest.text = newbest;
        warning.text = war;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
