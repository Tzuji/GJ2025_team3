using UnityEngine;
using UnityEngine.SceneManagement;

public class returnTitle : MonoBehaviour
{
    public void OnClickReturn()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
