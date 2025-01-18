using UnityEngine;
using UnityEngine.UI; // Для роботи з текстовими UI елементами

public class TriggerTextAndAnimation : MonoBehaviour
{
    public Text messageText; // Посилання на текстовий UI елемент
    public Animator animator; // Аніматор для відображення анімації
    public string openLidTrigger = "OpenLidAnimation"; // Назва тригера для відкриття кришки
    public string closeLidTrigger = "CloseLidAnimation"; // Назва тригера для закриття кришки

    private bool isPlayerInZone = false; // Чи знаходиться гравець у зоні
    private bool isLidOpen = false; // Чи відкрита кришка

    void Start()
    {
        // Ховаємо текст на початку
        if (messageText != null)
        {
            messageText.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Перевіряємо, чи гравець увійшов у зону
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;

            // Відображаємо текст для відкриття кришки
            if (messageText != null && !isLidOpen)
            {
                messageText.text = "Щоб відкрити кришку сміттєвого баку натисніть (Е)";
                messageText.enabled = true;
            }
            else if (messageText != null && isLidOpen)
            {
                messageText.text = "Щоб закрити кришку сміттєвого баку натисніть (Е)";
                messageText.enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Коли гравець залишає зону
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;

            // Ховаємо текст
            if (messageText != null)
            {
                messageText.enabled = false;
            }
        }
    }

    void Update()
    {
        // Перевіряємо, чи гравець натиснув "E" у зоні
        if (isPlayerInZone && Input.GetKeyDown(KeyCode.E))
        {
            if (animator != null)
            {
                if (!isLidOpen)
                {
                    // Відкриття кришки
                    animator.SetTrigger(openLidTrigger);
                    isLidOpen = true;

                    // Оновлення тексту
                    if (messageText != null)
                    {
                        messageText.text = "Щоб закрити кришку сміттєвого баку натисніть (Е)";
                    }
                }
                else
                {
                    // Закриття кришки
                    animator.SetTrigger(closeLidTrigger);
                    isLidOpen = false;

                    // Оновлення тексту
                    if (messageText != null)
                    {
                        messageText.text = "Щоб відкрити кришку сміттєвого баку натисніть (Е)";
                    }
                }
            }
        }
    }
}
