using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageText : MonoBehaviour
{
    public TextMeshProUGUI DefEnemy;
    void Update()
    {
        DefEnemy.text = "倒した敵: " + GameManager.Instance.enemiesDefeated;
    }
}
