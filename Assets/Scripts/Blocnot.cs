using UnityEngine;

public class Blocnot : MonoBehaviour
{
    public GameObject panel; // Панель, яку треба показати

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Перевіряємо, чи це гравець
        {
            panel.SetActive(true); // Вмикаємо панель
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false); // Ховаємо панель, коли виходимо з трігера (за бажанням)
        }
    }
}
