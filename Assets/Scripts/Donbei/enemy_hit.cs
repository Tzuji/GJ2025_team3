using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hit : MonoBehaviour
{
    [SerializeField]
    private GameObject gunObject;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            gameObject.SetActive(false);
            Destroy(gunObject.GetComponent<enemy>());
        }
        Debug.Log(this.gameObject.name);
    }
}
