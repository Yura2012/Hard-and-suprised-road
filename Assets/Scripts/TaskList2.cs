using UnityEngine;
using UnityEngine.UI;

public class TaskList2 : MonoBehaviour
{
    public Text messageText; // ���� ��� ����������� ������
    public string displayMessage = "��� ����� ����� �������� ������� (�)"; // �����������, ��� ���� ������������
    public GameObject packet;
    public Transform player;
    private bool isPlayerInTrigger = false; // �� ����������� ������� � ������

    void Start()
    {
        // ������ ����� �� ������� ���
        if (messageText != null)
        {
            messageText.text = "";
            messageText.enabled = false;
        }
    }

    void Update()
    {
        // ���������� ���������� ������ E
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            HideMessage();
            PickUpPacket();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ����������, �� �� �������
        if (other.CompareTag("Player"))
        {
            ShowMessage();
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ������ �����, ���� ������� ������ �� ���� �������
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
