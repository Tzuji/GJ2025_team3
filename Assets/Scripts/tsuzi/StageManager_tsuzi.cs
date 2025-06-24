using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager_tsuzi : MonoBehaviour
{
    public GameObject enemyPrefab;
    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        // 5秒後に敵1を出す
        if (timer > 2f && timer < 2.1f)
        {
            Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
        
        if (timer > 4f && timer < 4.1f)
        {
            Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }

        if (timer > 10f && timer < 10.1f)
        {
            SceneManager.LoadScene("Result");

        }
    }
}
