using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int enemiesDefeated = 0;
    public int score = 0;
    public bool PlayerAlive = true;
    public float playTime = 0f;
    private bool isTiming = false;

    void Update()
    {
        if (isTiming)
        {
            playTime += Time.deltaTime;
        }
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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

    //プレイ時間記録
    public void StartTimer()
    {
        playTime = 0f;
        isTiming = true;
    }

    public void StopTimer()
    {
        isTiming = false;
    }

}
