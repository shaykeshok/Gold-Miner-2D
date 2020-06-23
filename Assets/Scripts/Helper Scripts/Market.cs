using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    public static bool hasPower = false;
    public static bool hasClock = false;
    public static bool hasClow = false;
    //public static bool hasBomb = false;
    PopupMessage popupMessage;
    GameObject gameController;

    [SerializeField]
    private Text moneyText;

    void Start()
    {
        moneyText.text = "$ " + GameplayManager.allScore;
        gameController = GameObject.Find("GameController");
        popupMessage = gameController.GetComponent<PopupMessage>();
        //if (hasBomb)
        //{
        //    GameObject bomb = GameObject.Find("Bomb");
        //    bomb.SetActive(false);
        //}
        if (hasClock)
        {
            GameObject clock = GameObject.Find("Clock");
            clock.SetActive(false);
        }
        if (hasClow)
        {
            GameObject clow = GameObject.Find("Clow");
            clow.SetActive(false);
        }
        if (hasPower)
        {
            GameObject power = GameObject.Find("power");
            power.SetActive(false);
        }
    }
    public void getPower()
    {
        
        if (GameplayManager.allScore >= 500)
        {
            GameplayManager.allScore -= 500;
            moneyText.text = "$ " + GameplayManager.allScore;
            hasPower = true;
            GameObject power = GameObject.Find("power");
            power.SetActive(false);
        }
        else
        {
            popupMessage.Open("", "Sorry, You have'nt enough money to buy this product..");
        }
    }
    public void getClock()
    {
        if (GameplayManager.allScore >= 100)
        {
            GameplayManager.allScore -= 100;
            moneyText.text = "$ " + GameplayManager.allScore;
            hasClock = true;
            GameObject clock = GameObject.Find("Clock");
            clock.SetActive(false);
        }
        else
        {
            popupMessage.Open("", "Sorry, You have'nt enough money to buy this product..");
        }
    }
    public void getClow()
    {
        if (GameplayManager.allScore >= 200)
        {
            GameplayManager.allScore -= 200;
            moneyText.text = "$ " + GameplayManager.allScore;
            hasClow = true;
            GameObject clow = GameObject.Find("Clow");
            clow.SetActive(false);
        }
        else
        {
            popupMessage.Open("", "Sorry, You have'nt enough money to buy this product..");
        }
    }
    public void getBomb()
    {
        popupMessage.Open("", "This Product is avaliable to Premium friends only.");
        //if (GameplayManager.allScore >= 150)
        //{
        //    GameplayManager.allScore -= 150;
        //    moneyText.text = "$ " + GameplayManager.allScore;
        //    //hasBomb = true;
        //    GameObject bomb = GameObject.Find("Bomb");
        //    bomb.SetActive(false);
        //}
        //else
        //{
        //    popupMessage.Open("", "Sorry, You have'nt enough money to buy this product..");
        //}
    }
    public void getDiamonds()
    {
        popupMessage.Open("", "This Product is avaliable to Premium friends only.");
    }

    internal static void resetMarket()
    {
        hasPower = false;
        hasClock = false;
        hasClow = false;
    }
}
