using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public string firstText = "Ви підійшли до об'єкта!";
    public string secondText = "Взаємодія з об'єктом...";
    public string thirdText = "Об'єкт розміщено!";

    public GameObject interactionText; // UI-текст при підході
    public GameObject placementText; // UI-текст після розміщення

    public Animator trashBagAnimator; // Аніматор для сміттєвого кулька (1 анімація)
    public Animator otherObjectAnimator; // Аніматор для іншого об'єкта (2 анімації)

    private bool isNear = false;
    private bool isPlaced = false;
    private bool animationPlayed = false;

    private void Start()
    {
        interactionText.SetActive(false);
        placementText.SetActive(false);
    }

    private void Update()
    {
        if (isNear && Input.GetMouseButtonDown(0)) // ЛКМ
        {
            StartCoroutine(ShowSecondText());
        }

        if (isPlaced && !animationPlayed && Input.GetKeyDown(KeyCode.E)) // Якщо об'єкт розміщено і натиснута E
        {
            StartCoroutine(PlayAnimations());
            animationPlayed = true; // Щоб сміттєвий кульок анімували лише один раз
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
            interactionText.SetActive(true);
            interactionText.GetComponent<Text>().text = firstText;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            interactionText.SetActive(false);
        }
    }

    private IEnumerator ShowSecondText()
    {
        interactionText.GetComponent<Text>().text = secondText;
        yield return new WaitForSeconds(3);
        interactionText.SetActive(false);
    }

    public void PlaceObject()
    {
        isPlaced = true;
        placementText.SetActive(true);
        placementText.GetComponent<Text>().text = thirdText;
    }

    private IEnumerator PlayAnimations()
    {
        // Анімація сміттєвого кулька (лише один раз)
        trashBagAnimator.Play("TrashBagAnimation");
        yield return new WaitForSeconds(trashBagAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Перша анімація іншого об'єкта
        otherObjectAnimator.Play("FirstOtherObjectAnimation");
        yield return new WaitForSeconds(otherObjectAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Друга анімація іншого об'єкта
        otherObjectAnimator.Play("SecondOtherObjectAnimation");
    }
}