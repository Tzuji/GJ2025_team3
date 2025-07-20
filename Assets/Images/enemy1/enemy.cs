using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;  // �e�̃v���n�u
    [SerializeField] private Transform firePoint;      // �e�����ʒu
    [SerializeField] private float shootInterval = 2f; // �C���X�y�N�^�[����ύX�\�Ȕ��ˊԊu

    private float shootTimer = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null)
        {
            Debug.LogError("Player�^�O�̃I�u�W�F�N�g��������܂���I");
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
