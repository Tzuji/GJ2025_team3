using UnityEngine;
using TMPro;  // TextMeshPro を使う場合

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI sumScore;
    public TextMeshProUGUI ClearBonus;

    void Start()
    {
        int s = 0;

        resultText.text = "倒した敵の数: " + GameManager.Instance.enemiesDefeated;

        if (GameManager.Instance.PlayerAlive)
        {
            s = 100000000;
            ClearBonus.text = "クリアボーナス +100000000";
        }

        s += GameManager.Instance.score;
        sumScore.text = "スコア: " + s;

    }
}