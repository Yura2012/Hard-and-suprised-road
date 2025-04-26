using UnityEngine;

public class Blocnot : MonoBehaviour
{
    public GameObject panel; // ������, ��� ����� ��������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ����������, �� �� �������
        {
            panel.SetActive(true); // ������� ������
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false); // ������ ������, ���� �������� � ������ (�� ��������)
        }
    }
}
