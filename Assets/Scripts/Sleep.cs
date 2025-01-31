using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleep : MonoBehaviour
{
    public Slider SleepBar;
    private bool isInTrigger = false; // �������� ����������� � ������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���������� ������
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = false;
        }
    }

    private void Update()
    {
        if (isInTrigger && SleepBar.value <= 25 && Input.GetKeyDown(KeyCode.Q))
        {
            print("HI");
            SleepBar.value = 100;
        }
    }
}

