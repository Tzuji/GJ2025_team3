using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;  // 弾のプレハブ
    [SerializeField] private Transform firePoint;      // 弾を撃つ位置
    [SerializeField] private float shootInterval = 2f; // インスペクターから変更可能な発射間隔

    private float shootTimer = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null)
        {
            Debug.LogError("Playerタグのオブジェクトが見つかりません！");
        }
    }

    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || player == null) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        HomingBullet homing = bullet.GetComponent<HomingBullet>();
        if (homing != null)
        {
            homing.target = player;
        }

        Destroy(bullet, 10f);
    }
}
