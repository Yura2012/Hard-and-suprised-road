using UnityEngine;
using UnityEngine.UI;

public class TrashBin : MonoBehaviour
{
    private bool lidOpen = false;
    public Animator animator;
    public Text interactionText;

    private void Start()
    {

    }

    private void Update()
    {
        // ���� ������� ����������� �� ����
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < 3f)
        {
            if (!lidOpen)
            {
                interactionText.gameObject.SetActive(true);
                interactionText.text = "�������� E, ��� ������� ������ �������� ����";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    OpenLid();
                }
            }
            else
            {
                interactionText.gameObject.SetActive(true);
                interactionText.text = "�������� E, ��� �������� �����";
             
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ThrowTrash();
                }
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    private void OpenLid()
    {
        lidOpen = true;
        interactionText.gameObject.SetActive(false);
        animator.SetTrigger("openLidTrigger");
     
    }

    private void ThrowTrash()
    {
        interactionText.gameObject.SetActive(false);
        // ����� ������ ������� ��������� ������
        // ����� ������ ���� � ���
        Debug.Log("����� �������� � ���!");
        CloseLid(); // ��������� ������ ���� ���������
    }

    private void CloseLid()
    {
        lidOpen = false;
        animator.SetTrigger("closeLidTrigger");
    }
}
