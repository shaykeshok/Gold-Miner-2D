using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public SceneFader fader;

    public Button[] levelButtons;

    public Button goToShop;

    [SerializeField]
    private Text rankTxt;

    [SerializeField]
    public GameObject rankImgSuccess;

    [SerializeField]
    public GameObject rankImgFailed;

    void Start()
    {
        if (GameplayManager.success && GameplayManager.thisLevel== GameplayManager.levelReached) GameplayManager.levelReached++;

        int levelReached = GameplayManager.levelReached;
        //if (GameplayManager.success != 0)
        //{
        //    //GameObject rankSuccess = GameObject.Find("rankSuccess");
        //    //rankSuccess.SetActive(GameplayManager.success == 1);
        //    //GameObject rankFailed = GameObject.Find("rankFailed");
        //    //rankFailed.SetActive(GameplayManager.success == 2);
        //    //rankImgSuccess.enabled = GameplayManager.success == 1;
        //    //rankImgSuccess.setActive(false);
        //    //rankImgFailed.enabled = GameplayManager.success == 2;
        //    rankImgSuccess.SetActive(GameplayManager.success == 1);
        //    rankImgFailed.SetActive(GameplayManager.success == 2);
        //    string msg = GameplayManager.success==1 ? "Success level " : "Faild level ";
        //    msg += (levelReached - 1).ToString();
        //    //rankTxt.enabled = true;
        //    //GameObject rankTxtO = GameObject.Find("rankTxt");
        //    //rankTxtO.SetActive(true);

        //    //rankTxt.text = msg;

        //}

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
       
    }

    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }

    public void GotoShop()
    {
        fader.FadeTo("Market");
    }

}