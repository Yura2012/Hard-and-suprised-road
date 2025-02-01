using UnityEngine;

public class TrashBag : MonoBehaviour
{
    private bool isPickedUp = false;
    private InteractionController interactionController;

    private void Start()
    {
        // Знаходимо InteractionController у сцені
        interactionController = FindObjectOfType<InteractionController>();
    }

    private void Update()
    {
        // Якщо гравець наближається до пакету
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < 3f)
        {
            if (!isPickedUp)
            {
                interactionController.ShowText("Натисніть E, щоб взяти сміттєвий пакет");
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
        interactionController.HideText(); // Приховуємо текст
        transform.SetParent(Camera.main.transform); // Пакет стає дочірнім до камери
        transform.localPosition = new Vector3(0.5f, -0.5f, 2f); // Розташування пакету
    }
}
