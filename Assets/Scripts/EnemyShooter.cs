using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;   // �e�̃v���n�u
    public Transform player;          // �v���C���[��Transform
    public int bulletCount = 10;      // ���˂���e�̐�
    public float bulletSpeed = 5f;    // �e�̃X�s�[�h
    public float spreadAngle = 60f;   // ��̊J���i�x�j

    public float fireInterval = 2f;   // ���ˊԊu
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

        // �v���C���[�̕����x�N�g��
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
