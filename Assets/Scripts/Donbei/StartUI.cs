using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    private GameObject Canvas;
    void Start()
    {
        Canvas = GameObject.Find("StartUI");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            this.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            Canvas.SetActive(false);
            SceneManager.LoadScene("donbei");
        }
        Debug.Log("touched");
    }
}
