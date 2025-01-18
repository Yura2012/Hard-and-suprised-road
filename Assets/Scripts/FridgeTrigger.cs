using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeTrigger : MonoBehaviour
{
    public Animator Door;
    public bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {

        if (isOpen == true)
        {
            Door.Play("OpenFridgeleft, OpenFridgeright");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isOpen == true)
        {
            Door.Play("CloseFridgeright, CloseFridgelift");
        }
    }
}
