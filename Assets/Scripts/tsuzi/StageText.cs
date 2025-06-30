using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageText : MonoBehaviour
{
    public TextMeshProUGUI DefEnemy;
    public TextMeshProUGUI Time;
    void Update()
    {
        DefEnemy.text = "倒した敵：" + GameManager.Instance.enemiesDefeated;

        float time = GameManager.Instance.playTime;
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        Time.text = string.Format("経過時間：{0:00}:{1:00}", minutes, seconds);
    }
}
