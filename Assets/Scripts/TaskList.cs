using UnityEngine;
using UnityEngine.UI;

public class TaskList : MonoBehaviour
{
    public GameObject taskPanel; // ������ � ������� �������
    public Text interactionText; // ����� �������
    private bool isPlayerNearby = false; // �� ����� �������?

    void Start()
    {
        // �������� ��������� ������ � ����� �������
        taskPanel.SetActive(false);
        interactionText.enabled = false;
    }

    void Update()
    {
        // ���� ������� ����������� ����� � ������� E
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // ���������� �������� ����� �������
            taskPanel.SetActive(!taskPanel.activeSelf);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� ������� ������� � ���� �������
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactionText.enabled = true; // �������� ����� �������
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ���� ������� �������� �� ���� �������
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionText.enabled = false; // ��������� ����� �������
            taskPanel.SetActive(false); // ��������� ������
        }
    }
}
