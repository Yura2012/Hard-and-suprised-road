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
    public Animator Animator1;
    public GameObject prefab; // Посилання на префаб
    public GameObject emptyGameObject; // Порожній об'єкт, де потрібно створити префаб

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
                GameObject newObject = Instantiate(prefab, emptyGameObject.transform.position, emptyGameObject.transform.rotation);
                Destroy(newObject, 3f); // Знищити через 3 секунди
                WorkProgress.value = 0;
                MoneyCounterScript.Money += Payment;
                canWork = false;
                Animator1.enabled = false;
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
