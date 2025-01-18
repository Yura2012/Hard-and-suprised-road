using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FridgeManager : MonoBehaviour
{
    public int AppleMax, MivinaMax;
    public int AppleAmount, MivinaAmount;
    public Text AppleText, MivinaText;
    public Slider HP, Thirst, Hunger;
    public GameObject FridgeUiObj;
    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Hunger.value -= 1 * Time.deltaTime;
        Hunger.value -= 2 * Time.deltaTime;
        // Оновлення тексту для відображення кількості яблук
        AppleText.text = "Apple: "+AppleAmount.ToString() + " / " + AppleMax.ToString();

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
    public void close()
    {
        FridgeUiObj.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
