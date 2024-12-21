using UnityEngine;
using UnityEngine.UI;
public class StopSoundAndHideText : MonoBehaviour
{
    public AudioSource audioSource; 
    public Text uiText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop(); 
            }

            if (uiText != null)
            {
                uiText.enabled = false; 
            }
        }
    }
}
