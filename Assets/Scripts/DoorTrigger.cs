using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator Door;
    public bool isOpen = false;
    public GameObject Text;

    private void OnTriggerEnter(Collider other)
    {
        if(isOpen == false)
        {
            Text.SetActive(true);
        }

        if(isOpen == true)
        {
            Door.Play("OpenDoor");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(isOpen == false)
        {
            Text.SetActive(false);
        }
        if (isOpen == true)
        {
            Door.Play("CloseDoor");
        }
    }
}
