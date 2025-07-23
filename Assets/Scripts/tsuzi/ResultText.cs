using UnityEngine;
using TMPro;  // TextMeshPro を使う場合

public class ResultText : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI sumScore;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI ClearBonus;
    public int s = 0;

    void Start()
    {
        s = 0;
        
        resultText.text = "倒した敵の数: " + GameManager.Instance.enemiesDefeated;

        if (GameManager.Instance.PlayerAlive)
        {
            s = 100000000;
            ClearBonus.text = "クリアボーナス +100,000,000";
        }

        float time = GameManager.Instance.playTime;
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        timeText.text = string.Format("経過時間：{0:00}:{1:00}", minutes, seconds);
        int time_i = Mathf.FloorToInt(time);

        s += GameManager.Instance.score;
        s -= time_i;
        sumScore.text = "スコア: " + s;

    }
}