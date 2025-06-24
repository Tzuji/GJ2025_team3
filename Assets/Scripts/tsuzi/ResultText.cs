using UnityEngine;
using TMPro;  // TextMeshPro を使う場合

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    void Start()
    {
        int defeated = GameManager.Instance.enemiesDefeated;
        resultText.text = "倒した敵の数: " + defeated;
    }
}