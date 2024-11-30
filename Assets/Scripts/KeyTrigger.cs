using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public GameObject Key;
    public GameObject Text;
    public DoorTrigger DoorScript;

    private void OnTriggerEnter(Collider other)
    {
        DoorScript.isOpen = true;
        Text.SetActive(true);
        Destroy(Text, 5f);
        Destroy(Key);
    }
}
