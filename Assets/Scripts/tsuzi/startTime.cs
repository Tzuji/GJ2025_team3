using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTime : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.StartTimer();
    }

}
