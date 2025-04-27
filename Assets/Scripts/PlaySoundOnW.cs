using UnityEngine;

public class PlaySoundOnW : MonoBehaviour
{
    public AudioSource audioSource; // Тут присвоїш свій AudioSource в інспекторі

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
