using UnityEngine;
using UnityEngine.UI;

public class TaskList : MonoBehaviour
{
    public GameObject taskPanel; // Панель зі списком завдань
    public Text interactionText; // Текст підказки
    private bool isPlayerNearby = false; // Чи поруч гравець?

    void Start()
    {
        // Спочатку приховуємо панель і текст підказки
        taskPanel.SetActive(false);
        interactionText.enabled = false;
    }

    void Update()
    {
        // Якщо гравець знаходиться поруч і натискає E
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // Перемикаємо видимість панелі завдань
            taskPanel.SetActive(!taskPanel.activeSelf);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Коли гравець входить в зону тригера
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactionText.enabled = true; // Показуємо текст підказки
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Коли гравець виходить із зони тригера
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionText.enabled = false; // Приховуємо текст підказки
            taskPanel.SetActive(false); // Закриваємо панель
        }
    }
}
