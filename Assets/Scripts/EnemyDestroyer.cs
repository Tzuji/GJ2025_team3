using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject); // �����i�G�j���폜
            Destroy(other.gameObject); // �e���폜�i�C�Ӂj
        }
    }
}
