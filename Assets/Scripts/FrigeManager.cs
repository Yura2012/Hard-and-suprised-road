using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FridgeManager : MonoBehaviour
{
    public int AppleMax, BananaMax;
    public int AppleAmount, BananaAmount;
    public Text AppleText, BananaText;
    public Slider HP, Thirst, Hunger;
    public GameObject FridgeUiObj;
    public FirstPersonController FPScontroller;
    public GameObject FrigeCanvas;

            // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Hunger.value -= 1 * Time.deltaTime;
        Hunger.value -= 2 * Time.deltaTime;
        // Оновлення тексту для відображення кількості яблук
        AppleText.text = "Apple: " + AppleAmount.ToString() + " / " + AppleMax.ToString();
        AppleText.text = "Banana: " + BananaAmount.ToString() + " / " + BananaMax.ToString();

        // Зменшення HP, якщо значення Thirst або Hunger <= 0
        if (Thirst.value <= 0)
        {
            HP.value -= 2 * Time.deltaTime;
        }

        if (Hunger.value <= 0)
        {
            HP.value -= 1 * Time.deltaTime;
        }

        // Відновлення HP, якщо Hunger і Thirst > 50
        if (Hunger.value > 50 && Thirst.value > 50)
        {
            HP.value += 1 * Time.deltaTime;
        }
    }

    public void EatApple()
    {
        // Перевірка, чи є яблука в холодильнику
        if (AppleAmount > 0)
        {
            AppleAmount -= 1;
            Hunger.value += 10; // Наприклад, споживання яблука відновлює голод
        }
    }

    public void EatBanana()
    {
        // Перевірка, чи є яблука в холодильнику
        if (BananaAmount > 0)
        {
            BananaAmount -= 1;
            Hunger.value += 8; // Наприклад, споживання яблука відновлює голод
        }
    }

    public void close()
    {
        FridgeUiObj.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        FPScontroller.enabled = true;
        FrigeCanvas.SetActive(false);

}

}
