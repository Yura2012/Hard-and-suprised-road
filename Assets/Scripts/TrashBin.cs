using UnityEngine;

public class TrashBin : MonoBehaviour
{
    private bool lidOpen = false;
    private InteractionController interactionController;

    private void Start()
    {
        // Знаходимо InteractionController у сцені
        interactionController = FindObjectOfType<InteractionController>();
    }

    private void Update()
    {
        // Якщо гравець наближається до бака
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < 3f)
        {
            if (!lidOpen)
            {
                interactionController.ShowText("Натисніть E, щоб відкрити кришку сміттєвого бака");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    OpenLid();
                }
            }
            else
            {
                interactionController.ShowText("Натисніть E, щоб викинути сміття");
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
        transform.Find("Lid").Rotate(Vector3.right * 90); // Відкриваємо кришку
    }

    private void ThrowTrash()
    {
        interactionController.HideText();
        // Можна додати анімацію викидання пакету
        // Пакет просто падає в бак
        Debug.Log("Сміття викинуте в бак!");
        CloseLid(); // Закриваємо кришку після викидання
    }

    private void CloseLid()
    {
        lidOpen = false;
        transform.Find("Lid").Rotate(Vector3.left * 90); // Закриваємо кришку
    }
}
