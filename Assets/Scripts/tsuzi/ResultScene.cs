using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScene : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        if (Player == null)
        {
            SceneManager.LoadScene("Result");
            GameManager.Instance.StopTimer();

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Result");
            GameManager.Instance.StopTimer();
        }
    }
}
