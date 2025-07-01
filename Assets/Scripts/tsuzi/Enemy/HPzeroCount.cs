using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class HPzeroCount : MonoBehaviour
{
    void Update()
    {
        if (this.gameObject == null)
        {
            GameManager.Instance.AddScore(10);
        }
    }
}
