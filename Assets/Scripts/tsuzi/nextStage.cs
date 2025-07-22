using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextStage : MonoBehaviour
{
    public String nextSceneName;
    public GameObject Player;
    void Update()
    {
        if (Player == null)
        {
            SceneManager.LoadScene("Result");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
