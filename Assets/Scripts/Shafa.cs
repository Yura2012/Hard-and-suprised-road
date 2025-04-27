using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shafa : MonoBehaviour
{
    public GameObject text1; // Перший текст
    public GameObject text2; // Другий текст
    public Animator animator; // Аніматор
    public string firstAnimationTrigger = "FirstAnimation"; // Назва тригера для першої анімації
    public string secondAnimationTrigger = "SecondAnimation"; // Назва тригера для другої анімації

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
                    // Перше натискання E
                    firstEPressed = true;
                    text1.SetActive(false);
                    animator.Play(firstAnimationTrigger);
                    StartCoroutine(WaitAndShowSecondText());
                }
                else if (secondEAvailable && !secondEPressed)
                {
                    // Друге натискання E
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
