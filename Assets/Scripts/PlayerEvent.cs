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

        if (collider.gameObject.tag == "EnemyBullet")
        {
            Destroy(this.gameObject);
        }
        else if (collider.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
