using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BuyProducts : MonoBehaviour
{
    public GameObject FridgeUiObj;
    public FirstPersonController FPScontroller;
    public GameObject FrigeCanvas;
    public GameObject BuyCanvas;
    public FridgeManager fridgeManager;
    public MoneyCounter moneyCounter;

    public void BuyApple()
    {
        Debug.Log("BuyApple() CLICKED");
        if (fridgeManager.AppleAmount < fridgeManager.AppleMax && moneyCounter.Money >= 5)
        {
            fridgeManager.AppleAmount += 1;
            moneyCounter.Money -= 5;
            Debug.Log("Bought!");
        }
    }

    public void BuyBanana()
    {
        Debug.Log("BuyBanana() CLICKED");
        if (fridgeManager.BananaAmount < fridgeManager.BananaMax && moneyCounter.Money >= 4)
        {
            fridgeManager.BananaAmount += 1;
            moneyCounter.Money -= 4;
            Debug.Log("Bought!");
        }
    }


    public void BuyCake()
    {
        if (fridgeManager.CakeAmount < fridgeManager.CakeMax && moneyCounter.Money >= 6)
        {
            Debug.Log("BuyCake() CLICKED");
            fridgeManager.CakeAmount += 1;
            moneyCounter.Money -= 6;
            Debug.Log("Bought!");
        }
    }

    public void BuyWater()
    {
        if (fridgeManager.WaterAmount < fridgeManager.WaterMax && moneyCounter.Money >= 3)
        {
            Debug.Log("BuyWater() CLICKED");
            fridgeManager.WaterAmount += 1;
            moneyCounter.Money -= 3;
            Debug.Log("Bought!");
        }
    }

    public void close()
    {
        BuyCanvas.SetActive(false);
        FrigeCanvas.SetActive(true);
        FPScontroller.enabled = false;
    }
}
