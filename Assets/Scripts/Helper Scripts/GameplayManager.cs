using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameplayManager : MonoBehaviour
{

    public static GameplayManager instance;
    public static bool success = false;
    [SerializeField]
    private Text countdownText;

    public int countdownTimer = 60;

    [SerializeField]
    private Text scoreText;

    private int scoreCount;
    public static int allScore = 0;

    [SerializeField]
    private Image scoreFillUI;
    public static int thisLevel;

    public static int levelReached = 1;
    public SceneFader fader;
    private int level1;
    private int level2;
    private int level3;
    private int level4;
    //private int level5;
    //private int level6;
    private float sumScoreInThisLvl;
    private bool done = false;
    private bool StopCount = false;

    private bool startLevel;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // קורה לפני תחילת המשחק
    void Start()
    {
        startLevel = true;
        sumScoreInThisLvl = 0f;
        level1 = 0;
        level2 = 0;
        level3 = 0;
        level4 = 0;
        //level5 = 0;
        //level6 = 0;
        //formula(false);
        //resetFormula();
        done = false;

        DisplayScore(0);

        thisLevel = SceneManager.GetActiveScene().buildIndex;

        countdownText.text = countdownTimer.ToString();

        StartCoroutine("Countdown");



    }

    private void showOperators()
    {
        GameObject plus = GameObject.Find("plus");
        GameObject mult = GameObject.Find("mult");
        GameObject plus2 = GameObject.Find("plus2");
        GameObject minus = GameObject.Find("minus");
        GameObject divide = GameObject.Find("divide");

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                //"plus":
                plus.GetComponent<Text>().enabled = true;
                level1++;
                //"mult":
                mult.GetComponent<Text>().enabled = true;
                level1++;

                break;
            case 2:
                //"plus":
                plus.GetComponent<Text>().enabled = true;
                //"plus2":
                plus2.GetComponent<Text>().enabled = true;
                //"mult":
                mult.GetComponent<Text>().enabled = true;
                //"minus":
                minus.GetComponent<Text>().enabled = true;
                break;
            case 3:
                //"plus":
                plus.GetComponent<Text>().enabled = true;
                //"plus2":
                plus2.GetComponent<Text>().enabled = true;
                //"mult":
                mult.GetComponent<Text>().enabled = true;
                //"divide":
                divide.GetComponent<Text>().enabled = true;
                break;

        }
    }

    // הפונקצייה האחראית על הטיימר
    IEnumerator Countdown()
    {
        if (startLevel)
        {
            resetLevel();
            startLevel = false;
        }
        yield return new WaitForSeconds(1f);
        StopCount = false; ;

        countdownTimer -= 1;

        countdownText.text = countdownTimer.ToString();

        if (countdownTimer <= 10)
        {
            SoundManager.instance.TimeRunningOut(true);
        }

        StartCoroutine("Countdown");

        if (countdownTimer <= 0)
        {
            StopCoroutine("Countdown");
            Market.resetMarket();
            SoundManager.instance.GameEnd();
            SoundManager.instance.TimeRunningOut(false);

            GameObject lossTxt = GameObject.Find("loseTxt");
            lossTxt.GetComponent<Text>().enabled = true;
            success = false;
            StopCount = true;

            StartCoroutine(RestartGame(999));
        }

    } // ספירת הנקודות של השחקן

    private void resetLevel()
    {
        GameObject winTxt = GameObject.Find("winTxt");
        winTxt.GetComponent<Text>().enabled = false;
        GameObject lossTxt = GameObject.Find("loseTxt");
        lossTxt.GetComponent<Text>().enabled = false;

        if (Market.hasClock)
        {
            countdownTimer += 10;
            GameObject clock = GameObject.Find("clock");
            clock.GetComponent<Image>().enabled = true;
        }
        if (Market.hasPower)
        {
            GameObject power = GameObject.Find("power");
            power.GetComponent<Image>().enabled = true;

            //power.SetActive(false);
        }
        if (Market.hasClow)
        {
            showOperators();
            GameObject clow = GameObject.Find("Clow");
            clow.GetComponent<Image>().enabled = true;

            //clow.SetActive(false);
        }
        resetFormula();
    }

    public void DisplayScore(int scoreValue)
    {

        if (scoreText == null)
            return;
        if (StopCount)
            return;
        //תפיסת עצם שלא עוזר לפתרון הנוסחה
        if (scoreValue == 999)
        {
            scoreValue = 10;
            if (countdownTimer > 10)
            {
                countdownTimer -= 10;
            }
            else
            {
                StopCoroutine("Countdown");
                Market.resetMarket();
                SoundManager.instance.GameEnd();
                SoundManager.instance.TimeRunningOut(false);
                GameObject lossTxt = GameObject.Find("loseTxt");
                lossTxt.GetComponent<Text>().enabled = true;
                success = false;
                StopCount = true;
                StartCoroutine(RestartGame(999));
            }
        }
        else
        {
            formula(true);
        }

        scoreCount += scoreValue;
        allScore += scoreValue;
        scoreText.text = "$ " + scoreCount;

        scoreFillUI.fillAmount = (float)scoreCount / sumScoreInThisLvl;


        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                if (level1 == 5) done = true;
                break;
            case 2:
                if (level2 == 9) done = true;
                break;
            case 3:
                if (level3 == 9) done = true;
                break;
            case 4:
                if (level4 == 9) done = true;
                break;
                //case 5:
                //    if (level5 == 9) done = true;
                //    break;
                //case 6:
                //    if (level6 == 9) done = true;
                //    break;
        }

        if (done)
        {
            StopCoroutine("Countdown");
            SoundManager.instance.GameEnd();
            success = true;
            Market.resetMarket();
            //levelReached += 1;
            GameObject winTxt = GameObject.Find("winTxt");
            winTxt.GetComponent<Text>().enabled = true;
            StartCoroutine(RestartGame(1182));
            //SceneManager.LoadScene(3);
        }

    }

    //טיפול בנוסחה
    private void formula(bool show)
    {

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                sumScoreInThisLvl = 140f;
                switch (HookScript.itemValue)
                {
                    case "plus":
                        GameObject plus = GameObject.Find("plus");
                        plus.GetComponent<Text>().enabled = show;
                        level1++;
                        break;
                    case "four":
                        GameObject four = GameObject.Find("four");
                        four.GetComponent<Text>().enabled = show;
                        level1++;
                        break;
                    case "mult":
                        GameObject mult = GameObject.Find("mult");
                        mult.GetComponent<Text>().enabled = show;
                        level1++;
                        break;
                    case "three":
                        GameObject three = GameObject.Find("three");
                        three.GetComponent<Text>().enabled = show;
                        level1++;
                        break;
                    case "six":
                        GameObject six = GameObject.Find("six");
                        six.GetComponent<Text>().enabled = show;
                        level1++;
                        break;
                }
                break;
            case 2:
                sumScoreInThisLvl = 190f;
                switch (HookScript.itemValue)
                {
                    case "plus":
                        GameObject plus = GameObject.Find("plus");
                        plus.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "plus2":
                        GameObject plus2 = GameObject.Find("plus2");
                        plus2.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "mult":
                        GameObject mult = GameObject.Find("mult");
                        mult.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "nine":
                        GameObject nine = GameObject.Find("nine");
                        nine.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "five":
                        GameObject five = GameObject.Find("five");
                        five.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "eight":
                        GameObject eight = GameObject.Find("eight");
                        eight.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "seven":
                        GameObject seven = GameObject.Find("seven");
                        seven.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "minus":
                        GameObject minus = GameObject.Find("minus");
                        minus.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "one":
                        GameObject one = GameObject.Find("one");
                        one.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                }
                break;
            case 3:
                sumScoreInThisLvl = 210f;
                switch (HookScript.itemValue)
                {
                    case "plus":
                        GameObject plus = GameObject.Find("plus");
                        plus.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "plus2":
                        GameObject plus2 = GameObject.Find("plus2");
                        plus2.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "mult":
                        GameObject mult = GameObject.Find("mult");
                        mult.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "divide":
                        GameObject divide = GameObject.Find("divide");
                        divide.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "nine":
                        GameObject nine = GameObject.Find("nine");
                        nine.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "two":
                        GameObject two = GameObject.Find("two");
                        two.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "eight":
                        GameObject eight = GameObject.Find("eight");
                        eight.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "seven":
                        GameObject seven = GameObject.Find("seven");
                        seven.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "six":
                        GameObject six = GameObject.Find("six");
                        six.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                }
                break;
            case 4:
                sumScoreInThisLvl = 230f;
                switch (HookScript.itemValue)
                {
                    case "plus":
                        GameObject plus = GameObject.Find("plus");
                        plus.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "mult2":
                        GameObject mult2 = GameObject.Find("mult2");
                        mult2.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "mult":
                        GameObject mult = GameObject.Find("mult");
                        mult.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "divide":
                        GameObject divide = GameObject.Find("divide");
                        divide.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "nine":
                        GameObject nine = GameObject.Find("nine");
                        nine.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "two":
                        GameObject two = GameObject.Find("two");
                        two.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "nine2":
                        GameObject nine2 = GameObject.Find("nine2");
                        nine2.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "seven":
                        GameObject seven = GameObject.Find("seven");
                        seven.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                    case "five":
                        GameObject five = GameObject.Find("five");
                        five.GetComponent<Text>().enabled = show;
                        level2++;
                        break;
                }
                break;

        }
    }
    void resetFormula()
    {
        GameObject plus = GameObject.Find("plus");
        GameObject plus2 = GameObject.Find("plus2");
        GameObject minus = GameObject.Find("minus");
        GameObject mult = GameObject.Find("mult");
        GameObject divide = GameObject.Find("divide");
        GameObject one = GameObject.Find("one");
        GameObject two = GameObject.Find("two");
        GameObject three = GameObject.Find("three");
        GameObject four = GameObject.Find("four");
        GameObject five = GameObject.Find("five");
        GameObject six = GameObject.Find("six");
        GameObject seven = GameObject.Find("seven");
        GameObject eight = GameObject.Find("eight");
        GameObject nine = GameObject.Find("nine");
        GameObject mult2 = GameObject.Find("mult2");
        GameObject nine2 = GameObject.Find("nine2");
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                plus.GetComponent<Text>().enabled = false;
                four.GetComponent<Text>().enabled = false;
                mult.GetComponent<Text>().enabled = false;
                three.GetComponent<Text>().enabled = false;
                six.GetComponent<Text>().enabled = false;
                break;
            case 2:
                plus.GetComponent<Text>().enabled = false;
                plus2.GetComponent<Text>().enabled = false;
                mult.GetComponent<Text>().enabled = false;
                nine.GetComponent<Text>().enabled = false;
                five.GetComponent<Text>().enabled = false;
                eight.GetComponent<Text>().enabled = false;
                seven.GetComponent<Text>().enabled = false;
                minus.GetComponent<Text>().enabled = false;
                one.GetComponent<Text>().enabled = false;
                break;
            case 3:
                plus.GetComponent<Text>().enabled = false;
                plus2.GetComponent<Text>().enabled = false;
                mult.GetComponent<Text>().enabled = false;
                divide.GetComponent<Text>().enabled = false;
                nine.GetComponent<Text>().enabled = false;
                two.GetComponent<Text>().enabled = false;
                eight.GetComponent<Text>().enabled = false;
                seven.GetComponent<Text>().enabled = false;
                six.GetComponent<Text>().enabled = false;
                break;
            case 4:
                plus.GetComponent<Text>().enabled = false;
                mult2.GetComponent<Text>().enabled = false;
                mult.GetComponent<Text>().enabled = false;
                divide.GetComponent<Text>().enabled = false;
                nine.GetComponent<Text>().enabled = false;
                two.GetComponent<Text>().enabled = false;
                nine2.GetComponent<Text>().enabled = false;
                seven.GetComponent<Text>().enabled = false;
                five.GetComponent<Text>().enabled = false;
                break;
        }
    }
    // הפעלת המשחק מחדש ובהמשך הפעלת שלב הבא
    IEnumerator RestartGame(int scene)
    {
        yield return new WaitForSeconds(4f);
        //if (success) levelReached++;
        SceneManager.LoadScene(7);
    }

} // class
