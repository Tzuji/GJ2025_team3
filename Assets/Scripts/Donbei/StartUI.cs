using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    private GameObject Canvas;

    private void Start()
    {
        Canvas = GameObject.Find("StartUI");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            Canvas.SetActive(false);
            SceneManager.LoadScene("donbei");
        }

        Debug.Log("touched");
    }
}