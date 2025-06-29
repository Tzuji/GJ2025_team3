using UnityEngine;

public class DelEnemy : MonoBehaviour
{
    public int point = 1;
    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "PlayerBullet")
        {
            GameManager.Instance.AddEnemyDefeated();
            GameManager.Instance.AddScore(point);
            Destroy(this.gameObject);
        }
    }
}
