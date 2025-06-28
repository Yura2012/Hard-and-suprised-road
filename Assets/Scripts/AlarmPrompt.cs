using UnityEngine;
using UnityEngine.UI;

public class AlarmPrompt : MonoBehaviour
{
    public Text promptText;
    public AudioSource alarmSound;

    void Start()
    {
        if (promptText != null)
        {
            promptText.text = "To stop the alarm, press (E)";
            promptText.gameObject.SetActive(true);
        }

        if (alarmSound != null)
        {
            alarmSound.Play();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed!");

            if (promptText != null)
                promptText.gameObject.SetActive(false);

            if (alarmSound != null)
                alarmSound.Stop();
        }
    }
}

