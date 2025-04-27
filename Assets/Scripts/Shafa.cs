using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shafa : MonoBehaviour
{
    public GameObject text1; // ������ �����
    public GameObject text2; // ������ �����
    public Animator animator; // �������
    public string firstAnimationTrigger = "FirstAnimation"; // ����� ������� ��� ����� �������
    public string secondAnimationTrigger = "SecondAnimation"; // ����� ������� ��� ����� �������

    private bool isPlayerInTrigger = false;
    private bool firstEPressed = false;
    private bool secondEAvailable = false;
    private bool secondEPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            text1.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            ResetAll();
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!firstEPressed)
                {
                    // ����� ���������� E
                    firstEPressed = true;
                    text1.SetActive(false);
                    animator.Play(firstAnimationTrigger);
                    StartCoroutine(WaitAndShowSecondText());
                }
                else if (secondEAvailable && !secondEPressed)
                {
                    // ����� ���������� E
                    secondEPressed = true;
                    text2.SetActive(false);
                    animator.Play(secondAnimationTrigger);
                }
            }
        }
    }

    IEnumerator WaitAndShowSecondText()
    {
        yield return new WaitForSeconds(5f);
        text2.SetActive(true);
        secondEAvailable = true;
    }

    void ResetAll()
    {
        text1.SetActive(false);
        text2.SetActive(false);
        StopAllCoroutines();
        firstEPressed = false;
        secondEAvailable = false;
        secondEPressed = false;
    }
}
