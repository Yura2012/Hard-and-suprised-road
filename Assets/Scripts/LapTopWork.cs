using UnityEngine;
using UnityEngine.UI;

public class LapTopWork : MonoBehaviour
{
    public Slider WorkProgress;
    public int WorkAmount;
    public int Payment;
    public GameObject WorkSlider;
    public string NoticeText;
    public Text NoticeTextObj;
    public string CantWorkText;
    public MoneyCounter MoneyCounterScript;

    private bool isWorking = false;
    private bool canWork = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isWorking = true;
            canWork = true;
            EnableUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isWorking = false;
            canWork = false;
            DisableUI();
        }
    }

    private void Update()
    {
        if (!canWork) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            NoticeTextObj.text = NoticeText;
            WorkProgress.value += WorkAmount;

            if (WorkProgress.value >= 100)
            {
                WorkProgress.value = 0;
                MoneyCounterScript.Money += Payment;
                canWork = false;
                DisableUI();
            }
        }
    }

    private void EnableUI()
    {
        WorkSlider.SetActive(true);
        NoticeTextObj.enabled = true;
        NoticeTextObj.text = NoticeText;
    }

    private void DisableUI()
    {
        WorkSlider.SetActive(false);
        NoticeTextObj.enabled = false;
        NoticeTextObj.text = CantWorkText;
    }
}
