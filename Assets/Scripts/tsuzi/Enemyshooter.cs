using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform player;              // プレイヤーの Transform
    public float fireRate = 1.0f;         // 発射間隔
    public float lifeTime = 3f; //一定時間経過後削除
    public float bulletSpeed = 5f;
    public float bulletLifetime = 5f;
    public int bulletCount = 5;           // 扇状に撃つ弾の数
    public float spreadAngle = 45f;       // 扇形の全体角度（度）

    private float timer = 0f;

    void Start()
    {
        // lifeTime 秒後に自動で削除される
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        if (player == null) return;

        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            FireBulletsAtPlayer();
            timer = 0f;
        }
    }

    void FireBulletsAtPlayer()
{
    Vector2 dirToPlayer = (player.position - transform.position).normalized;
    float baseAngle = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg;

    float angleStep = spreadAngle / (bulletCount - 1);
    float startAngle = baseAngle - (spreadAngle / 2f);

    for (int i = 0; i < bulletCount; i++)
    {
        float angle = startAngle + angleStep * i;
        Vector2 bulletDir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Boundbullet mover = bullet.GetComponent<Boundbullet>();
        if (mover != null)
        {
            mover.moveDirection = bulletDir.normalized;
            mover.speed = bulletSpeed;
        }

        Destroy(bullet, bulletLifetime);
    }
}

}
