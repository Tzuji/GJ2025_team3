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
    }
}