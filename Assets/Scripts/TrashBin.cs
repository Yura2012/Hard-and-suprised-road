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
        // Якщо гравець наближається до бака
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < 3f)
        {
            if (!lidOpen)
            {
                interactionText.gameObject.SetActive(true);
                interactionText.text = "Натисніть E, щоб відкрити кришку сміттєвого бака";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    OpenLid();
                }
            }
            else
            {
                interactionText.gameObject.SetActive(true);
                interactionText.text = "Натисніть E, щоб викинути сміття";
             
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
        // Можна додати анімацію викидання пакету
        // Пакет просто падає в бак
        Debug.Log("Сміття викинуте в бак!");
        CloseLid(); // Закриваємо кришку після викидання
    }

    private void CloseLid()
    {
        lidOpen = false;
        animator.SetTrigger("closeLidTrigger");
    }
}
