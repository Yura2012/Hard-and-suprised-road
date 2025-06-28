using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SleepSystem : MonoBehaviour
{
    public GameObject sleepPanel; // Панель затемнення
    public Text sleepText; // Текст "Sleep zzZ"
    public Text promptText; // Текст "Щоб лягти спати..."
    public Slider Slider;

    private bool isNearBed = false;

    void Start()
    {
        sleepPanel.SetActive(false); // Спочатку ховаємо чорну панель
        promptText.gameObject.SetActive(false); // Ховаємо текст підказки
    }

    void Update()
    {
        if (isNearBed && Input.GetKeyDown(KeyCode.E)) // Якщо біля ліжка і натиснута "E"
        {
            StartCoroutine(SleepRoutine()); // Запускаємо сон
        }
    }

    private IEnumerator SleepRoutine()
    {
        sleepPanel.SetActive(true); // Показуємо чорну панель
        sleepText.gameObject.SetActive(true); // Показуємо текст "Sleep zzZ"
        yield return new WaitForSeconds(3); // Чекаємо 3 секунди
        Slider.value = 100;
        sleepPanel.SetActive(false); // Ховаємо чорну панель
        sleepText.gameObject.SetActive(false); // Ховаємо текст
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Якщо гравець зайшов у зону ліжка
        {
            isNearBed = true;
            promptText.gameObject.SetActive(true); // Показуємо підказку
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Якщо гравець вийшов із зони ліжка
        {
            isNearBed = false;
            promptText.gameObject.SetActive(false); // Ховаємо підказку
        }
    }
}
