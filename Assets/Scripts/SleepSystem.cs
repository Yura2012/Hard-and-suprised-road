using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SleepSystem : MonoBehaviour
{
    public GameObject sleepPanel; // ������ ����������
    public Text sleepText; // ����� "Sleep zzZ"
    public Text promptText; // ����� "��� ����� �����..."
    public Slider Slider;

    private bool isNearBed = false;

    void Start()
    {
        sleepPanel.SetActive(false); // �������� ������ ����� ������
        promptText.gameObject.SetActive(false); // ������ ����� �������
    }

    void Update()
    {
        if (isNearBed && Input.GetKeyDown(KeyCode.E)) // ���� ��� ���� � ��������� "E"
        {
            StartCoroutine(SleepRoutine()); // ��������� ���
        }
    }

    private IEnumerator SleepRoutine()
    {
        sleepPanel.SetActive(true); // �������� ����� ������
        sleepText.gameObject.SetActive(true); // �������� ����� "Sleep zzZ"
        yield return new WaitForSeconds(3); // ������ 3 �������
        Slider.value = 100;
        sleepPanel.SetActive(false); // ������ ����� ������
        sleepText.gameObject.SetActive(false); // ������ �����
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���� ������� ������ � ���� ����
        {
            isNearBed = true;
            promptText.gameObject.SetActive(true); // �������� �������
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // ���� ������� ������ �� ���� ����
        {
            isNearBed = false;
            promptText.gameObject.SetActive(false); // ������ �������
        }
    }
}
