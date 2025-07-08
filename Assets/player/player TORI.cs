using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("�ړ��ݒ�")]
    public float speed = 5f;

    [Header("�U���ݒ�")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.2f;
    private float fireTimer = 0f;

    public enum AttackType
    {
        Single,
        Wide,
        Rapid
    }
    public AttackType currentAttack = AttackType.Single;

    public int singleDamage = 1;
    public int wideDamage = 2;
    public int rapidDamage = 1;

    [Header("�̗͐ݒ�")]
    public int hp = 3;

    void Update()
    {
        HandleMovement();
        RestrictPosition();
        HandleAttackSwitch();
        HandleShooting();
    }

    // =========================
    // �ړ�����
    // =========================
    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(x, y) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    // =========================
    // �U���^�C�v�؂�ւ�
    // =========================
    void HandleAttackSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentAttack = AttackType.Single;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentAttack = AttackType.Wide;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentAttack = AttackType.Rapid;
    }

    // =========================
    // �e���ˏ���
    // =========================
    void HandleShooting()
    {
        fireTimer += Time.deltaTime;

        float currentFireRate = fireRate;
        if (currentAttack == AttackType.Rapid)
        {
            currentFireRate = fireRate / 3f;
        }

        if (Input.GetKey(KeyCode.Space) && fireTimer >= currentFireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    void Shoot()
    {
        switch (currentAttack)
        {
            case AttackType.Single:
                SpawnBullet(Quaternion.identity, singleDamage);
                break;

            case AttackType.Wide:
                float[] angles = { -15f, 0f, 15f };
                foreach (var angle in angles)
                {
                    SpawnBullet(Quaternion.Euler(0, 0, angle), wideDamage);
                }
                break;

            case AttackType.Rapid:
                SpawnBullet(Quaternion.identity, rapidDamage);
                break;
        }
    }

    void SpawnBullet(Quaternion rotation, int damage)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.damage = damage;
        }
    }

    // =========================
    // ��ʒ[����
    // =========================
    void RestrictPosition()
    {
        float screenRatio = (float)Screen.width / Screen.height;
        float orthographicSize = Camera.main.orthographicSize;

        float maxX = orthographicSize * screenRatio;
        float maxY = orthographicSize;

        Vector3 pos = transform.position;

        float paddingX = 0.5f;
        float paddingY = 0.5f;

        pos.x = Mathf.Clamp(pos.x, -maxX + paddingX, maxX - paddingX);
        pos.y = Mathf.Clamp(pos.y, -maxY + paddingY, maxY - paddingY);

        transform.position = pos;
    }

    // =========================
    // �_���[�W�����i�G�e�p�j
    // =========================
    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("�v���C���[��HP: " + hp);

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("�v���C���[�����S���܂���");
        Destroy(gameObject); // �Q�[���I�[�o�[��ʂւ̑J�ڂȂǂ�������
    }
}
