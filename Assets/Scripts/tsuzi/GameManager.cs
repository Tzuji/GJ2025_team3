using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int enemiesDefeated = 0;

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
}
