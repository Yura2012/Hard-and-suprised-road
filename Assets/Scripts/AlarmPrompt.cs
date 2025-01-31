using UnityEngine;
using UnityEngine.UI;

public class AlarmPrompt : MonoBehaviour
{
    public Text promptText; // Посилання на UI-текст у Canvas
    public AudioSource alarmSound; // Посилання на аудіо

    void Start()
    {
        // Встановлюємо текст на початку гри
        promptText.text = "Щоб зупинити будильник, натисни (E)";
        promptText.gameObject.SetActive(true);
        alarmSound.Play(); // Запускаємо звук
    }

    void Update()
    {
        // Перевіряємо, чи натиснута клавіша E
        if (Input.GetKeyDown(KeyCode.E))
        {
            promptText.gameObject.SetActive(false);
            alarmSound.Stop(); // Зупиняємо звук
        }
    }
}
