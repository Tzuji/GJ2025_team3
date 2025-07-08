using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hit : MonoBehaviour
{
    public int HP;

    [SerializeField]
    private GameObject gunObject;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            HP -= 1;
            if (HP <= 0)
            {
                Defeated();
            }
        }
        Debug.Log(this.gameObject.name);
    }
    void Defeated()
    {
        GameManager.Instance?.AddEnemyDefeated();
        gameObject.SetActive(false);
        Destroy(gunObject?.GetComponent<enemy>());

        //倒した敵によってスコアに加算するポイントを変更bytsuji
        if (this.gameObject.name == "boss")
        {
            GameManager.Instance.AddScore(50);
        }
        else
        {
            GameManager.Instance.AddScore(10);
        }
    }
}