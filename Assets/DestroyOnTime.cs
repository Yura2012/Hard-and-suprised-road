using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    public float TimeToDestroy;
    void Start()
    {
        Destroy(gameObject, TimeToDestroy);
    }


}
