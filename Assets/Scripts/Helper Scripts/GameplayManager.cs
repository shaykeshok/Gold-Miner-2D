using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameplayManager : MonoBehaviour {

    public static GameplayManager instance;

    [SerializeField]
    private Text countdownText;

    public int countdownTimer = 60;

    [SerializeField]
    private Text scoreText;

    private int scoreCount;

    [SerializeField]
    private Image scoreFillUI;

    void Awake() {
        if (instance == null)
            instance = this;
    }

    // קורה לפני תחילת המשחק
    void Start() {

        DisplayScore(0);

        countdownText.text = countdownTimer.ToString();

        StartCoroutine("Countdown");

    }

    // הפונקצייה האחראית על הטיימר
    IEnumerator Countdown() {
        yield return new WaitForSeconds(1f);

        countdownTimer -= 1;

        countdownText.text = countdownTimer.ToString();

        if(countdownTimer <= 10) {
            SoundManager.instance.TimeRunningOut(true);
        }

        StartCoroutine("Countdown");

        if(countdownTimer <= 0) {
            StopCoroutine("Countdown");

            SoundManager.instance.GameEnd();
            SoundManager.instance.TimeRunningOut(false);

            StartCoroutine(RestartGame(999));
        }

    } // ספירת הנקודות של השחקן

    public void DisplayScore(int scoreValue) {

        if (scoreText == null)
            return;
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
                SoundManager.instance.GameEnd();
                StartCoroutine(RestartGame(999));
            }
        }
        scoreCount += scoreValue;
        scoreText.text = "$ " + scoreCount;

        scoreFillUI.fillAmount = (float)scoreCount / 100f;

        if(scoreCount >= 100) {
            StopCoroutine("Countdown");
            SoundManager.instance.GameEnd();
            StartCoroutine(RestartGame(1182));
        }

    }

    // הפעלת המשחק מחדש ובהמשך הפעלת שלב הבא
    IEnumerator RestartGame(int scene) {
        yield return new WaitForSeconds(4f);
        string sceneName = "MainMenu";
        switch (scene)
        {
            case 0:
                sceneName = "Menu";
                break;
            case 1:
                sceneName = "level1";
                break;
            case 2:
                sceneName = "level2";
                break;
            case 1182:
                sceneName = "Victory";
                break;
            case 999:
                sceneName = "GameOver";
                break;
        }
        //SceneManager.LoadScene(sceneName);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

} // class
