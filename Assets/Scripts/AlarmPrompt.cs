using UnityEngine;
using UnityEngine.UI;

public class AlarmPrompt : MonoBehaviour
{
    public Text promptText; // ��������� �� UI-����� � Canvas
    public AudioSource alarmSound; // ��������� �� ����

    void Start()
    {
        // ������������ ����� �� ������� ���
        promptText.text = "��� �������� ���������, ������� (E)";
        promptText.gameObject.SetActive(true);
        alarmSound.Play(); // ��������� ����
    }

    void Update()
    {
        // ����������, �� ��������� ������ E
        if (Input.GetKeyDown(KeyCode.E))
        {
            promptText.gameObject.SetActive(false);
            alarmSound.Stop(); // ��������� ����
        }
    }
}
