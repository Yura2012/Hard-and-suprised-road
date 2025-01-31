using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    public Slider Thirst;

    void Update()
    {
        Thirst.value -= 4 * Time.deltaTime;
    }
}
