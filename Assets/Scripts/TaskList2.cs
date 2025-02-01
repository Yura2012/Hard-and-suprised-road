using UnityEngine;
using UnityEngine.UI;

public class TaskList2 : MonoBehaviour
{
    public Text messageText; // Поле для відображення тексту
    public string displayMessage = "Щоб взяти сміття натисніть клавашу (Е)"; // Повідомлення, яке буде відображатись
    public GameObject packet;
    public Transform player;
    private bool isPlayerInTrigger = false; // Чи знаходиться гравець у тригері

    void Start()
    {
        // Ховаємо текст на початку гри
        if (messageText != null)
        {
            messageText.text = "";
            messageText.enabled = false;
        }
    }

    void Update()
    {
        // Перевіряємо натискання клавіші E
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            HideMessage();
            PickUpPacket();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Перевіряємо, чи це гравець
        if (other.CompareTag("Player"))
        {
            ShowMessage();
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Ховаємо текст, якщо гравець вийшов із зони тригера
        if (other.CompareTag("Player"))
        {
            HideMessage();
            isPlayerInTrigger = false;
        }
    }

    private void ShowMessage()
    {
        if (messageText != null)
        {
            messageText.text = displayMessage;
            messageText.enabled = true;
        }
    }

    private void HideMessage()
    {
        if (messageText != null)
        {
            messageText.text = "";
            messageText.enabled = false;
        }
    }

    private void PickUpPacket()
    {
        packet.transform.SetParent(player);
      packet.transform.position = new Vector3(-4.61f, -1.33f, 1.29f);
    }
}
