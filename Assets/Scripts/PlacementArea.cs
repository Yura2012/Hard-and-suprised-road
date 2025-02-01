using UnityEngine;

public class PlacementArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            other.GetComponent<InteractableObject>().PlaceObject();
        }
    }
}