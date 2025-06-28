using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hungering : MonoBehaviour
{
    public Slider Thirst;
    public Slider Hunger;
    public Slider Fatigue;
    public Slider HP;

    void Update()
    {
        if (Thirst == null || Hunger == null || Fatigue == null || HP == null)
        {
            Debug.LogWarning("❗ Один із слайдерів не призначений у інспекторі!");
            return;
        }

        Thirst.value -= 1 * Time.deltaTime;
        Hunger.value -= 1 * Time.deltaTime;
        Fatigue.value -= 1 * Time.deltaTime;

        if (Thirst.value <= 0)
            HP.value -= 2 * Time.deltaTime;

        if (Hunger.value <= 0)
            HP.value -= 1 * Time.deltaTime;

        if (Fatigue.value <= 0)
            HP.value -= 1 * Time.deltaTime;

        if (Hunger.value > 50 && Thirst.value > 50 && Fatigue.value > 50)
            HP.value += 1 * Time.deltaTime;
    }
}
