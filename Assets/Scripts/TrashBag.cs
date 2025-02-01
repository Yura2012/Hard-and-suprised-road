using UnityEngine;

public class TrashBag : MonoBehaviour
{
    private bool isPickedUp = false;
    private InteractionController interactionController;

    private void Start()
    {
        // ��������� InteractionController � ����
        interactionController = FindObjectOfType<InteractionController>();
    }

    private void Update()
    {
        // ���� ������� ����������� �� ������
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < 3f)
        {
            if (!isPickedUp)
            {
                interactionController.ShowText("�������� E, ��� ����� ������� �����");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PickUp();
                }
            }
        }
        else
        {
            interactionController.HideText();
        }
    }

    private void PickUp()
    {
        isPickedUp = true;
        interactionController.HideText(); // ��������� �����
        transform.SetParent(Camera.main.transform); // ����� ��� ������� �� ������
        transform.localPosition = new Vector3(0.5f, -0.5f, 2f); // ������������ ������
    }
}
