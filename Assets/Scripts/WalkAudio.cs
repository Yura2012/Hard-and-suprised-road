using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAudio : MonoBehaviour
{
    public AudioSource audioSource;


    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }
}
