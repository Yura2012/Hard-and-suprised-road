using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeTrigger : MonoBehaviour
{
    public GameObject FrigeCanvas;
    public Animator Door;
    public bool isOpen = false;
    public FirstPersonController FPSController;

    private void Start()
    {
        FrigeCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (isOpen == true)
        {
            Door.Play("OpenFridgeleft");
            FPSController.enabled = false;
            FrigeCanvas.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isOpen == true)
        {
            Door.Play("CloseFridgeright");
            FPSController.enabled = true;
            FrigeCanvas.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
