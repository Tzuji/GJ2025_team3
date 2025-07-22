using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int enemiesDefeated = 0;
    public int score = 0;
    public bool PlayerAlive = true;
    public float playTime = 0f;
    private bool isTiming = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    void Update()
    {
        if (isTiming)
        {
            playTime += Time.deltaTime;
        }
    }

    public void AddEnemyDefeated()
    {
        enemiesDefeated++;
        Debug.Log("倒した敵の数: " + enemiesDefeated);
    }

    public void AddScore(int point)
    {
        score += point * 100;
        Debug.Log("スコア: " + score);
    }

    public void PlayerDestloy()
    {
        PlayerAlive = false;
        Debug.Log("死亡");
    }

    public void StartTimer()
    {
        playTime = 0f;
        isTiming = true;
    }

    public void StopTimer()
    {
        isTiming = false;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("scene loaded: " + scene.name);
        if (scene.name == "StartMenu")
        {
            enemiesDefeated = 0;
        }
    }
}
