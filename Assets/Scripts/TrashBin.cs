using UnityEngine;

public class TrashBin : MonoBehaviour
{
    private bool lidOpen = false;
    private InteractionController interactionController;

    private void Start()
    {
        // ��������� InteractionController � ����
        interactionController = FindObjectOfType<InteractionController>();
    }

    private void Update()
    {
        // ���� ������� ����������� �� ����
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < 3f)
        {
            if (!lidOpen)
            {
                interactionController.ShowText("�������� E, ��� ������� ������ �������� ����");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    OpenLid();
                }
            }
            else
            {
                interactionController.ShowText("�������� E, ��� �������� �����");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ThrowTrash();
                }
            }
        }
        else
        {
            interactionController.HideText();
        }
    }

    private void OpenLid()
    {
        lidOpen = true;
        interactionController.HideText();
        transform.Find("Lid").Rotate(Vector3.right * 90); // ³�������� ������
    }

    private void ThrowTrash()
    {
        interactionController.HideText();
        // ����� ������ ������� ��������� ������
        // ����� ������ ���� � ���
        Debug.Log("����� �������� � ���!");
        CloseLid(); // ��������� ������ ���� ���������
    }

    private void CloseLid()
    {
        lidOpen = false;
        transform.Find("Lid").Rotate(Vector3.left * 90); // ��������� ������
    }
}
