using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            gameObject.SetActive(false);
        }
        Debug.Log("touched");
    }
}
