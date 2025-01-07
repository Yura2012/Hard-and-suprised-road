using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public int Money;
    public Text MoneyText;
    public string MoneyTextText;

    public void Update()
    {
        MoneyText.text = MoneyTextText + Money;
    }


}
