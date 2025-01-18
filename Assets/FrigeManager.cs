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
        // ��������� ������ ��� ����������� ������� �����
        AppleText.text = "Apple: "+AppleAmount.ToString() + " / " + AppleMax.ToString();

        // ��������� HP, ���� �������� Thirst ��� Hunger <= 0
        if (Thirst.value <= 0)
        {
            HP.value -= 2 * Time.deltaTime;
        }

        if (Hunger.value <= 0)
        {
            HP.value -= 1 * Time.deltaTime;
        }

        // ³��������� HP, ���� Hunger � Thirst > 50
        if (Hunger.value > 50 && Thirst.value > 50)
        {
            HP.value += 1 * Time.deltaTime;
        }
    }

    public void EatApple()
    {
        // ��������, �� � ������ � ������������
        if (AppleAmount > 0)
        {
            AppleAmount -= 1;
            Hunger.value += 10; // ���������, ���������� ������ �������� �����
        }
    }
    public void close()
    {
        FridgeUiObj.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
