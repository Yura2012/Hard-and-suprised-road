using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Canvas Canvas;
    public MoneyCounter moneyCounter;

    private void Update()
    {
        if (moneyCounter.Money >= 2000)
        {
            Canvas.gameObject.SetActive(true); // Показати Canvas
        }
        else
        {
            Canvas.gameObject.SetActive(false); // Сховати Canvas
        }
    }
}

