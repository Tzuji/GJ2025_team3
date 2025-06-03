using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject); // ©•ªi“Gj‚ğíœ
            Destroy(other.gameObject); // ’e‚àíœi”CˆÓj
        }
    }
}
