using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int enemiesDefeated = 0;
    public int score = 0;
    public bool PlayerAlive = true;

    void Awake()
    {
        // シングルトン化（ゲーム中にGameManagerは1つだけ）
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // シーンが変わっても消えない
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddEnemyDefeated()
    {
        enemiesDefeated++;
        Debug.Log("倒した敵の数: " + enemiesDefeated);
    }

    public void AddScore(int point) {
        score += point*10;
        Debug.Log("スコア: " + score);
    }

    public void PlayerDestloy()
    {
        PlayerAlive = false;
        Debug.Log("死亡");
    }
}
