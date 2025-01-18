using UnityEngine;
using UnityEngine.UI; // ��� ������ � ���������� UI ����������

public class TriggerTextAndAnimation : MonoBehaviour
{
    public Text messageText; // ��������� �� ��������� UI �������
    public Animator animator; // ������� ��� ����������� �������
    public string openLidTrigger = "OpenLidAnimation"; // ����� ������� ��� �������� ������
    public string closeLidTrigger = "CloseLidAnimation"; // ����� ������� ��� �������� ������

    private bool isPlayerInZone = false; // �� ����������� ������� � ���
    private bool isLidOpen = false; // �� ������� ������

    void Start()
    {
        // ������ ����� �� �������
        if (messageText != null)
        {
            messageText.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // ����������, �� ������� ������ � ����
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;

            // ³��������� ����� ��� �������� ������
            if (messageText != null && !isLidOpen)
            {
                messageText.text = "��� ������� ������ �������� ���� �������� (�)";
                messageText.enabled = true;
            }
            else if (messageText != null && isLidOpen)
            {
                messageText.text = "��� ������� ������ �������� ���� �������� (�)";
                messageText.enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // ���� ������� ������ ����
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;

            // ������ �����
            if (messageText != null)
            {
                messageText.enabled = false;
            }
        }
    }

    void Update()
    {
        // ����������, �� ������� �������� "E" � ���
        if (isPlayerInZone && Input.GetKeyDown(KeyCode.E))
        {
            if (animator != null)
            {
                if (!isLidOpen)
                {
                    // ³������� ������
                    animator.SetTrigger(openLidTrigger);
                    isLidOpen = true;

                    // ��������� ������
                    if (messageText != null)
                    {
                        messageText.text = "��� ������� ������ �������� ���� �������� (�)";
                    }
                }
                else
                {
                    // �������� ������
                    animator.SetTrigger(closeLidTrigger);
                    isLidOpen = false;

                    // ��������� ������
                    if (messageText != null)
                    {
                        messageText.text = "��� ������� ������ �������� ���� �������� (�)";
                    }
                }
            }
        }
    }
}
