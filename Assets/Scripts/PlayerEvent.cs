using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collision");

        if (collider.gameObject.tag == "EnemyBullet")
        {
            Destroy(this.gameObject);
        }

    }
}
