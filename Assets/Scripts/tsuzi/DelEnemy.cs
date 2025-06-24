using UnityEngine;

public class DelEnemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D EnemyCollider)
    {
        if (EnemyCollider.gameObject.tag == "PlayerBullet")
        {
            GameManager.Instance.AddEnemyDefeated();
            Destroy(this.gameObject);
        }
    }
}
