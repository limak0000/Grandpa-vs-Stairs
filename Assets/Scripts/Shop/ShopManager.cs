using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour {

    public Text itemName;
    public Text LvText;
    public Image LvBar;
    public Text itemDetail;

    public GameObject JumpingText;

    public GameObject Lv1Button;
    public GameObject Lv2Button;
    public GameObject Lv3Button;
    public GameObject Lv4Button;
    public GameObject Lv5Button;
    public GameObject unlockButton;

    public int itemNumber;
    float itemLv;
    public float maxLv;
    bool Lvmax;
    //Vector3 TextShow;

    public void LvOne ()
    {
        if (itemNumber == 1) { PowerFeet(500, 60); }
        else if (itemNumber == 2) { EagleEye(500, 2); }
        else if (itemNumber == 3) { GoldPlus(500, 20); }
        else if (itemNumber == 4) { BananaPlus(500, 10); }
        else if (itemNumber == 5) { SuperBone(500, 150f); }
        else if (itemNumber == 6) { IronHead(500, 4.5f); }
        else if (itemNumber == 7) { LessBan(500, 8); }
        else if (itemNumber == 9) { SuperBody(500, 0.8f); }

    }

    public void LvTwo()
    {
        if (itemNumber == 1) { PowerFeet(1000, 120); }
        else if (itemNumber == 2) { EagleEye(1000, 4); }
        else if (itemNumber == 3) { GoldPlus(1000, 50); }
        else if (itemNumber == 4) { BananaPlus(1000, 30); }
        else if (itemNumber == 5) { SuperBone(1000, 200f); }
        else if (itemNumber == 6) { IronHead(1000, 4.5f); }
        else if (itemNumber == 7) { LessBan(1000, 6); }
        else if (itemNumber == 9) { SuperBody(1000, 0.6f); }

    }

    public void LvThree()
    {
        if (itemNumber == 1) { PowerFeet(3000, 180); }
        else if (itemNumber == 2) { EagleEye(3000, 6); }
        else if (itemNumber == 3) { GoldPlus(3000, 100); }
        else if (itemNumber == 4) { BananaPlus(3000, 60); }
        else if (itemNumber == 5) { SuperBone(3000, 300f); }
        else if (itemNumber == 6) { IronHead(3000, 4f); }
        else if (itemNumber == 7) { LessBan(3000, 5); }
        else if (itemNumber == 9) { SuperBody(3000, 0.5f); }

    }

    public void LvFour()
    {
        if (itemNumber == 1) { PowerFeet(5000, 240); }
        else if (itemNumber == 2) { EagleEye(5000, 8); }
        else if (itemNumber == 3) { GoldPlus(5000, 150); }
        else if (itemNumber == 4) { BananaPlus(5000, 80); }
        else if (itemNumber == 5) { SuperBone(5000, 400f); }
        else if (itemNumber == 6) { IronHead(5000, 3.5f); }
        else if (itemNumber == 7) { LessBan(5000, 4); }
        else if (itemNumber == 9) { SuperBody(5000, 0.4f); }

    }

    public void LvFive()
    {
        if (itemNumber == 1) { PowerFeet(10000, 300); }
        else if (itemNumber == 2) { EagleEye(10000, 10); }
        else if (itemNumber == 3) { GoldPlus(10000, 200); }
        else if (itemNumber == 4) { BananaPlus(10000, 100); }
        else if (itemNumber == 5) { SuperBone(10000, 500f); }
        else if (itemNumber == 6) { IronHead(10000, 2f); }
        else if (itemNumber == 7) { LessBan(10000, 3); }
        else if (itemNumber == 9) { SuperBody(10000, 0.3f); }

    }

    public void Unlock()
    {
        if (itemNumber == 8)
        {
            if (PlayerPrefs.GetInt("Coins", 0) >= 10000)
            {
                PlayerPrefs.SetInt("DoubleJumpNum", 1);
                CoinCount.TotalCoins -= 10000;
                PlayerPrefs.SetInt("Coins", CoinCount.TotalCoins);
                PlayerPrefs.SetFloat("Item008Lv", 99);
                itemLv = PlayerPrefs.GetFloat("Item008Lv", 0);
            }
            else
            {
                noMoney();
            }
        }
        if (itemNumber == 10)
        {
            if (PlayerPrefs.GetInt("Coins", 0) >= 10000)
            {
                PlayerPrefs.SetInt("SlowMoNum", 1);
                CoinCount.TotalCoins -= 10000;
                PlayerPrefs.SetInt("Coins", CoinCount.TotalCoins);
                PlayerPrefs.SetFloat("Item010Lv", 99);
                itemLv = PlayerPrefs.GetFloat("Item010Lv", 0);
            }
            else
            {
                noMoney();
            }
        }
        if (itemNumber == 11)
        {
            if (PlayerPrefs.GetInt("Coins", 0) >= 5000)
            {
                PlayerPrefs.SetInt("TouchingGold", 1);
                CoinCount.TotalCoins -= 5000;
                PlayerPrefs.SetInt("Coins", CoinCount.TotalCoins);
                PlayerPrefs.SetFloat("Item011Lv", 99);
                itemLv = PlayerPrefs.GetFloat("Item011Lv", 0);
            }
            else
            {
                noMoney();
            }
        }
    }

    void PowerFeet(int money, int force)
    {
        if (PlayerPrefs.GetInt("Coins", 0) >= money)
        {
            CoinCount.TotalCoins -= money;
            PlayerPrefs.SetInt("Coins", CoinCount.TotalCoins);
            itemLv++;
            PlayerPrefs.SetFloat("Item001Lv", itemLv);

            PlayerPrefs.SetInt("JumpForce", force);
            LvBar.fillAmount = itemLv / maxLv;
        }
        else
        {
            noMoney();
        }
    } // 1

    void EagleEye(int money, int chance)
    {
        if (PlayerPrefs.GetInt("Coins", 0) >= money)
        {
            CoinCount.TotalCoins -= money;
            PlayerPrefs.SetInt("Coins", CoinCount.TotalCoins);
            itemLv++;
            PlayerPrefs.SetFloat("Item002Lv", itemLv);

            PlayerPrefs.SetInt("CoinChance", chance);
            LvBar.fillAmount = itemLv / maxLv;
        }
        else
        {
            noMoney();
        }
    } // 2 

    void GoldPlus (int money, int value)
    {
        if (PlayerPrefs.GetInt("Coins", 0) >= money)
        {
            CoinCount.TotalCoins -= money;
            PlayerPrefs.SetInt("Coins", CoinCount.TotalCoins);
            itemLv++;
            PlayerPrefs.SetFloat("Item003Lv", itemLv);

            PlayerPrefs.SetInt("CoinValue", value);
            LvBar.fillAmount = itemLv / maxLv;
        }
        else
        {
            noMoney();
        }
    } //3

    void BananaPlus(int money, int value)
    {
        if (PlayerPrefs.GetInt("Coins", 0) >= money)
        {
            CoinCount.TotalCoins -= money;
            PlayerPrefs.SetInt("Coins", CoinCount.TotalCoins);
            itemLv++;
            PlayerPrefs.SetFloat("Item004Lv", itemLv);

            PlayerPrefs.SetInt("BananaValue", value);
            LvBar.fillAmount = itemLv / maxLv;
        }
        else
        {
            noMoney();
        }
    } //4

    void SuperBone(int money, float hp)
    {
        if (PlayerPrefs.GetInt("Coins", 0) >= money)
        {
            CoinCount.TotalCoins -= money;
            PlayerPrefs.SetInt("Coins", CoinCount.TotalCoins);
            itemLv++;
            PlayerPrefs.SetFloat("Item005Lv", itemLv);

            PlayerPrefs.SetFloat("MaxHP", hp);
            LvBar.fillAmount = itemLv / maxLv;
        }
        else
        {
            noMoney();
        }
    } //5

    void IronHead(int money, float dmg)
    {
        if (PlayerPrefs.GetInt("Coins", 0) >= money)
        {
            CoinCount.TotalCoins -= money;
            PlayerPrefs.SetInt("Coins", CoinCount.TotalCoins);
            itemLv++;
            PlayerPrefs.SetFloat("Item006Lv", itemLv);

            PlayerPrefs.SetFloat("DMG", dmg);
            LvBar.fillAmount = itemLv / maxLv;
        }
        else
        {
            noMoney();
        }
    } //6

    void LessBan(int money, int count)
    {
        if (PlayerPrefs.GetInt("Coins", 0) >= money)
        {
            CoinCount.TotalCoins -= money;
            PlayerPrefs.SetInt("Coins", CoinCount.TotalCoins);
            itemLv++;
            PlayerPrefs.SetFloat("Item007Lv", itemLv);

            PlayerPrefs.SetInt("MaxWrongCount", count);
            LvBar.fillAmount = itemLv / maxLv;
        }
        else
        {
            noMoney();
        }
    } //7

    void SuperBody(int money, float rate)
    {
        if (PlayerPrefs.GetInt("Coins", 0) >= money)
        {
            CoinCount.TotalCoins -= money;
            PlayerPrefs.SetInt("Coins", CoinCount.TotalCoins);
            itemLv++;
            PlayerPrefs.SetFloat("Item009Lv", itemLv);

            PlayerPrefs.SetFloat("Rate", rate);
            LvBar.fillAmount = itemLv / maxLv;
        }
        else
        {
            noMoney();
        }
    } //9

    public void Home()
    {
        //AdManager.instance.DestroyBanner();
        Time.timeScale = 1;
        ScoreCount.Score = 0;
        SceneManager.LoadScene(0);
    }

    // Use this for initialization
    void Start () {
        
        TextSetting();
        if (itemNumber == 1) { itemLv = PlayerPrefs.GetFloat("Item001Lv", 0); }
        else if (itemNumber == 2) { itemLv = PlayerPrefs.GetFloat("Item002Lv", 0); }
        else if (itemNumber == 3) { itemLv = PlayerPrefs.GetFloat("Item003Lv", 0); }
        else if (itemNumber == 4) { itemLv = PlayerPrefs.GetFloat("Item004Lv", 0); }
        else if (itemNumber == 5) { itemLv = PlayerPrefs.GetFloat("Item005Lv", 0); }
        else if (itemNumber == 6) { itemLv = PlayerPrefs.GetFloat("Item006Lv", 0); }
        else if (itemNumber == 7) { itemLv = PlayerPrefs.GetFloat("Item007Lv", 0); }
        else if (itemNumber == 8)
        {
            if (PlayerPrefs.GetFloat("Item008Lv", 0) == 0) { PlayerPrefs.SetFloat("Item008Lv", 100); }
            itemLv = PlayerPrefs.GetFloat("Item008Lv", 0);
        }
        else if (itemNumber == 9) { itemLv = PlayerPrefs.GetFloat("Item009Lv", 0); }
        else if (itemNumber == 10)
        {
            if (PlayerPrefs.GetFloat("Item010Lv", 0) == 0) { PlayerPrefs.SetFloat("Item010Lv", 100); }
            itemLv = PlayerPrefs.GetFloat("Item010Lv", 0);
        }
        else if (itemNumber == 11)
        {
            if (PlayerPrefs.GetFloat("Item011Lv", 0) == 0) { PlayerPrefs.SetFloat("Item011Lv", 100); }
            itemLv = PlayerPrefs.GetFloat("Item011Lv", 0);
        }

        LvBar.fillAmount = itemLv / maxLv;

        //AdManager.instance.RequestBanner();
    }

    public void TextSetting()
    {
        switch (itemNumber)
        {
            case 1:
                SwitchText("Mighty Leg", "Increase the jumping distance of Grandpa", "腿肌強化", "增加阿伯跳躍距離", "力強い足", "ジャンプ距離を伸ばす", "शक्तिशाली पैर", "दादाजी की कूद दूरी बढ़ाएँ", "다리 근육 강화", "노인의 점프 거리를 늘리십시오", "Jambe Puissante", "Augmenter la distance de saut de grand-père", "Mächtiges Bein", "Erhöhen Sie die Sprungdistanz von Opa", "Mighty Leg", "Aumentare la distanza di salto del nonno", "Могучая нога", "Увеличьте прыгучесть старика", "ขาแข็งแรง", "เพิ่มระยะการกระโดดของชายชรา");
                break;
            case 2:
                SwitchText("Gold Finder", "Increase the opportunity of coins appearing", "尋金大師", "增加金幣出現機率", "ゴールドファインダー", "金貨が出現する可能性を高める", "गोल्ड फाइंडर", "सिक्कों के दिखने के अवसर को बढ़ाएं", "골드 파인더", "금화가 나타날 가능성을 높입니다", "De l'or partout", "Plus de pièces apparaîtront", "Gold Finder", "Erhöhen Sie die Chance, dass Münzen erscheinen", "Cercatore d'oro", "Più monete appariranno", "Золотой Искатель", "Больше монет будет появляться", "สายตาที่ดี", "เพิ่มโอกาสในการปรากฏเหรียญ");
                break;
            case 3:
                SwitchText("Value Soared", "Increase the value of each coin", "金價飆升", "增加每枚金幣價值", "金価格が高騰", "各コインの価値を上げる", "सोने का भाव बढ़ा", "प्रत्येक सिक्के का मूल्य बढ़ाएं", "골드 가격 상승", "각 동전의 가치를 올리십시오", "Hausse des prix", "Augmenter la valeur de chaque pièce d'or", "Goldpreisanstieg", "Erhöhen Sie den Wert jeder Münze", "Aumento dei prezzi", "Aumentare il valore di ogni moneta", "Рост цен", "Увеличьте ценность каждой монеты", "เงินเฟ้อ", "เพิ่มมูลค่าของแต่ละเหรียญ");
                break;
            case 4:
                SwitchText("Banana Business", "Increase the value of each banana peel", "蕉皮鍊金", "增加每隻蕉皮價值", "バナナは貴重です", "各バナナの皮の価値を高めなさい", "अनमोल केला", "प्रत्येक केले के छिलके का मूल्य बढ़ाएं", "귀중한 바나나 껍질", "각 바나나 스킨의 가치 높이기", "Affaires de banane", "Augmenter la valeur de chaque peau de banane", "Bananengeschäft", "Erhöhen Sie den Wert jeder Bananenschale", "Banana Business", "Aumentare il valore di ciascuna buccia di banana", "Банановый бизнес", "Увеличьте ценность каждой банановой кожуры", "ธุรกิจกล้วย", "เพิ่มมูลค่าของเปลือกกล้วยแต่ละใบ");
                break;
            case 5:
                SwitchText("Super Bone", "Increase the maximum bone density of Grandpa", "骨骼強化", "增加阿伯最大骨密度", "骨を強化", "最大骨密度を上げる", "सुपर हड्डी", "अधिकतम अस्थि घनत्व बढ़ाएँ", "뼈 강화", "노인의 최대 뼈 밀도를 높이십시오", "Super os", "Augmenter la densité osseuse maximale", "Knochenverstärkung", "Erhöhen Sie die maximale Knochendichte", "Rinforzo osseo", "Aumentare la densità ossea massima del nonno", "Супер кость", "Увеличить максимальную плотность костей у старика", "การเสริมกระดูก", "เพิ่มความหนาแน่นของกระดูกสูงสุดของชายชรา");
                break;
            case 6:
                SwitchText("Iron Head", "Reduce the damage during head touching the ground", "鋼鐵頭顱", "減輕阿伯頭部觸地傷害", "アイアンヘッド", "頭が地面に触れたときのダメージを軽減", "लोहे का सर", "सिर को जमीन से छूने पर क्षति को कम करें", "철 해골", "노인의 머리가 땅에 닿는 동안의 피해 감소", "Tête de fer", "Réduit les dégâts en touchant la tête au sol", "Eisenkopf", "Reduzieren Sie den Schaden, wenn Opas Kopf den Boden berührt", "Testa di Ferro", "Riduci il danno quando la testa del Nonno tocca il suolo", "Железная голова", "Уменьшите урон, когда голова дедушки касается земли", "หัวเหล็ก", "ลดความเสียหายเมื่อศีรษะสัมผัสกับพื้น");
                break;
            case 7:
                SwitchText("Accuracy", "Reduce the maximum number of ❌", "熟能生巧", "減少❌最大次數", "熟練した経験", "❌の最大数を減らす", "समृद्ध अनुभव", "की अधिकतम संख्या को कम ❌", "베테랑", "❌의 최대 수를 줄입니다", "Précision", "Réduire le nombre maximum de ❌", "Richtigkeit", "Reduzieren Sie die maximale Anzahl von ❌", "Precisione", "Ridurre il numero massimo di ❌", "точность", "Уменьшить максимальное количество ❌", "ความถูกต้อง", "ลดจำนวนสูงสุดของ❌");
                break;
            case 8:
                SwitchText("Double Jump", "Able to make two jumps in the air", "絕世輕功", "在空中可以進行二段跳躍", "ダブルジャンプ", "空中で2回ジャンプできる", "दोहरी कूद", "हवा में दो छलांग लगाने में सक्षम", "더블 점프", "공중에서 두 번의 점프가 가능하다", "Double Saut", "Capable de faire deux sauts en l'air", "Doppelsprung", "Kann zwei Sprünge in die Luft machen", "Doppio Salto", "In grado di fare due salti in aria", "Двойной прыжок", "Способен сделать два прыжка в воздухе", "กระโดดสองครั้ง", "สามารถกระโดดได้สองครั้งในอากาศ");
                break;
            case 9:
                SwitchText("Super Body", "Reduce crit damage", "銅皮鐵骨", "減輕踩蕉皮墮地傷害", "スチールボディ", "クリティカルダメージを軽減", "सुपर बॉडी", "गंभीर क्षति को कम करें", "슈퍼 바디", "치명적인 피해 감소", "Super Corps", "Réduire les dégâts critiques", "Super Body", "Kritischer Schaden reduzieren", "Super Body", "Ridurre il danno critico", "Супер тело", "Уменьшить критический урон", "สุดยอดร่างกาย", "ลดความเสียหายที่สำคัญ");
                break;
            case 10:
                SwitchText("Slow Landing", "Increase reaction time when landing", "凌波微步", "跳躍後落地增加反應時間", "完璧な着陸", "ジャンプ後の着地は 反応時間を増加させる", "धीमी लैंडिंग", "लैंडिंग के समय प्रतिक्रिया समय बढ़ाएं", "슬로우 랜딩", "점프 후 착륙시 반응 시간이 증가 함", "Atterrissage Lent", "Augmente le temps de réaction à l'atterrissage", "Langsame Landung", "Erhöhen Sie die Reaktionszeit bei der Landung", "Atterraggio Lento", "Aumentare il tempo di reazione durante l'atterraggio", "Медленная посадка", "Увеличьте время реакции при посадке", "ช้าลง", "เพิ่มเวลาตอบสนองเมื่อลงจอด");
                break;
            case 11:
                SwitchText("Coin Catcher", "Coins can also be obtained by physical contact", "金幣捕手", "身體接觸也可以獲得金幣", "金貨キャッチャー", "金はまた物理的な接触 によって得ることができます", "सिक्का कैचर", "सिक्के शारीरिक संपर्क द्वारा भी प्राप्त किए जा सकते हैं", "동전 포수", "동전은 또한 물리적 접촉에 의해 얻을 수 있습니다", "Coin Catcher", "Les pièces peuvent également être obtenues par contact physique", "Münze Catcher", "Münzen können auch durch körperlichen Kontakt erhalten werden", "Coin Catcher", "Le monete possono anche essere ottenute per contatto fisico", "Ловец монет", "Монеты также могут быть получены путем физического контакта", "เครื่องจับเหรียญ", "เหรียญยังสามารถได้รับจากการสัมผัสทางกายภาพ");
                break;
        }
    }

    void noMoney()
    {
        switch (PlayerPrefs.GetInt("LanguageCode", 0))
        {
            case 0:
                JumpingTextManager.Instance.CreateCoinText(JumpingText.transform.position, "Not Enough Coins", Color.white); break;
            case 1:
                JumpingTextManager.Instance.CreateCoinText(JumpingText.transform.position, "金幣不足", Color.white); break;
            case 2:
                JumpingTextManager.Instance.CreateCoinText(JumpingText.transform.position, "金貨は十分ではありません", Color.white); break;
            case 3:
                JumpingTextManager.Instance.CreateCoinText(JumpingText.transform.position, "पर्याप्त सिक्के नहीं है", Color.white); break;
            case 4:
                JumpingTextManager.Instance.CreateCoinText(JumpingText.transform.position, "충분하지 않은 동전", Color.white); break;
            case 5:
                JumpingTextManager.Instance.CreateCoinText(JumpingText.transform.position, "Pas assez de pièces", Color.white); break;
            case 6:
                JumpingTextManager.Instance.CreateCoinText(JumpingText.transform.position, "Nicht genug Münzen", Color.white); break;
            case 7:
                JumpingTextManager.Instance.CreateCoinText(JumpingText.transform.position, "Non abbastanza monete", Color.white); break;
            case 8:
                JumpingTextManager.Instance.CreateCoinText(JumpingText.transform.position, "Недостаточно монет", Color.white); break;
            case 9:
                JumpingTextManager.Instance.CreateCoinText(JumpingText.transform.position, "เหรียญไม่พอ", Color.white); break;
        }
    }

    void SwitchText(string name01, string detail01, string name02, string detail02, string name03, string detail03,
        string name04, string detail04, string name05, string detail05, string name06, string detail06,string name07, 
        string detail07, string name08, string detail08, string name09, string detail09, string name10, string detail10)
    {
        switch (PlayerPrefs.GetInt("LanguageCode", 0))
        {
            case 0:
                BasicText(name01, detail01); break;
            case 1:
                BasicText(name02, detail02); break;
            case 2:
                BasicText(name03, detail03); break;
            case 3:
                BasicText(name04, detail04); break;
            case 4:
                BasicText(name05, detail05); break;
            case 5:
                BasicText(name06, detail06); break;
            case 6:
                BasicText(name07, detail07); break;
            case 7:
                BasicText(name08, detail08); break;
            case 8:
                BasicText(name09, detail09); break;
            case 9:
                BasicText(name10, detail10); break;
        }
    }

    void BasicText(string name, string detail)
    {
        itemName.text = name;
        //itemName.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        itemDetail.text = detail;
        switch (PlayerPrefs.GetInt("LanguageCode", 0))
        {
            case 0:
                itemDetail.fontStyle = FontStyle.Normal;
                break;
            case 5:
                itemDetail.fontStyle = FontStyle.Normal;
                break;
            case 6:
                itemDetail.fontStyle = FontStyle.Normal;
                break;
            case 7:
                itemDetail.fontStyle = FontStyle.Normal;
                break;
        }
        //itemDetail.font = Resources.GetBuiltinResource(typeof(Font), "Minercraftory") as Font;
        //itemDetail.fontSize = 0;
        //itemDetail.fontStyle = FontStyle.Bold;
    }

    // Update is called once per frame
    void Update() {

        switch ((int) itemLv)
        {
            case 0:
                NonActiveButton("Lv. 0", Lv1Button, Lv2Button, Lv3Button, Lv4Button, Lv5Button);
                break;
            case 1:
                NonActiveButton("Lv. 1", Lv2Button, Lv1Button, Lv3Button, Lv4Button, Lv5Button);
                break;
            case 2:
                NonActiveButton("Lv. 2", Lv3Button, Lv1Button, Lv2Button, Lv4Button, Lv5Button);
                break;
            case 3:
                NonActiveButton("Lv. 3", Lv4Button, Lv1Button, Lv3Button, Lv2Button, Lv5Button);
                break;
            case 4:
                NonActiveButton("Lv. 4", Lv5Button, Lv1Button, Lv3Button, Lv4Button, Lv2Button);
                break;
            case 5:
                Lvmax = true;
                NonActiveButton("Lv. Max", Lv1Button, Lv2Button, Lv3Button, Lv4Button, Lv5Button);
                break;
            case 99:
                unlockButton.SetActive(false);
                LvText.text = "UNLOCKED";
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            PlayerPrefs.DeleteAll();
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(PlayerPrefs.GetInt("JumpForce", 0));
            PlayerPrefs.SetInt("Coins", 9999999);
        }
    }

    void NonActiveButton(string lv, GameObject A, GameObject B1, GameObject B2, GameObject B3, GameObject B4)
    {
        LvText.text = lv;
        if (!Lvmax) { A.SetActive(true); }
        else { A.SetActive(false); }
        B1.SetActive(false);
        B2.SetActive(false);
        B3.SetActive(false);
        B4.SetActive(false);
    }
}
