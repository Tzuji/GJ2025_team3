using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;   // 弾のプレハブ
    public Transform player;          // プレイヤーのTransform
    public int bulletCount = 10;      // 発射する弾の数
    public float bulletSpeed = 5f;    // 弾のスピード
    public float spreadAngle = 60f;   // 扇の開き（度）

    public float fireInterval = 2f;   // 発射間隔
    private float fireTimer = 0f;

    void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireInterval)
        {
            Fire();
            fireTimer = 0f;
        }
    }

    void Fire()
    {
        if (player == null) return;

        // プレイヤーの方向ベクトル
        Vector2 dirToPlayer = (player.position - transform.position).normalized;
        float baseAngle = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg;

        float startAngle = baseAngle - spreadAngle / 2f;
        float angleStep = spreadAngle / (bulletCount - 1);

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = startAngle + angleStep * i;
            float rad = angle * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
        }
    }
}
