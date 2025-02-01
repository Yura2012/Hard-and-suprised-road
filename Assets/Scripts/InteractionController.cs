using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    public Text interactionText; // Текст для підказок
    private Canvas canvas;

    private void Awake()
    {
        // Шукаємо Canvas та текст на ньому
        canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            interactionText = canvas.GetComponentInChildren<Text>();
            interactionText.gameObject.SetActive(false); // Текст прихований на початку
        }
    }

    // Виведення тексту взаємодії
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
