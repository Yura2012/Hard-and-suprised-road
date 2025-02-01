using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public string firstText = "�� ������ �� ��'����!";
    public string secondText = "������� � ��'�����...";
    public string thirdText = "��'��� ��������!";

    public GameObject interactionText; // UI-����� ��� �����
    public GameObject placementText; // UI-����� ���� ���������

    public Animator trashBagAnimator; // ������� ��� �������� ������ (1 �������)
    public Animator otherObjectAnimator; // ������� ��� ������ ��'���� (2 �������)

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
        if (isNear && Input.GetMouseButtonDown(0)) // ���
        {
            StartCoroutine(ShowSecondText());
        }

        if (isPlaced && !animationPlayed && Input.GetKeyDown(KeyCode.E)) // ���� ��'��� �������� � ��������� E
        {
            StartCoroutine(PlayAnimations());
            animationPlayed = true; // ��� ������� ������ �������� ���� ���� ���
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
        // ������� �������� ������ (���� ���� ���)
        trashBagAnimator.Play("TrashBagAnimation");
        yield return new WaitForSeconds(trashBagAnimator.GetCurrentAnimatorStateInfo(0).length);

        // ����� ������� ������ ��'����
        otherObjectAnimator.Play("FirstOtherObjectAnimation");
        yield return new WaitForSeconds(otherObjectAnimator.GetCurrentAnimatorStateInfo(0).length);

        // ����� ������� ������ ��'����
        otherObjectAnimator.Play("SecondOtherObjectAnimation");
    }
}