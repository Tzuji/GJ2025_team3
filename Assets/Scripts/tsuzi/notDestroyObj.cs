using UnityEngine;

public class NotDestroyObj : MonoBehaviour
{
    private static bool isLoaded = false;

    private void Awake()
    {
        if (isLoaded)
        {
            Destroy(gameObject);
            return;
        }

        isLoaded = true;
        DontDestroyOnLoad(gameObject);
    }
}
