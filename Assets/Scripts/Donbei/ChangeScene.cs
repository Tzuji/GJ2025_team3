using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nextSceneName;
    public GameObject Player;

    private void Update()
    {
        if (Player is null)
        {
            SceneManager.LoadScene("Result");
            GameManager.Instance.StopTimer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet")) SceneManager.LoadScene(nextSceneName);
    }
}