using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    public Text interactionText; // ����� ��� �������
    private Canvas canvas;

    private void Awake()
    {
        // ������ Canvas �� ����� �� �����
        canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            interactionText = canvas.GetComponentInChildren<Text>();
            interactionText.gameObject.SetActive(false); // ����� ���������� �� �������
        }
    }

    // ��������� ������ �����䳿
    public void ShowText(string text)
    {
        if (interactionText != null)
        {
            interactionText.text = text;
            interactionText.gameObject.SetActive(true);
        }
    }

    public void HideText()
    {
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
    }
}
