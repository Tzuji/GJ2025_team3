using UnityEngine;

public class Cplayer : MonoBehaviour
{
    public float speed = 1f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private Rigidbody2D rb;
    private Vector2 movementInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D ���A�^�b�`����Ă��܂���I");
        }
    }

    void Update()
    {
        // ���͎擾�i�����̂݁j
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        movementInput = new Vector2(h, v);

        // �e����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void FixedUpdate()
    {
        // �����x�[�X�ňړ��i�����蔻��L���j
        if (rb != null)
        {
            Vector2 newPos = rb.position + movementInput * speed * Time.fixedDeltaTime;
            rb.MovePosition(newPos);
        }
    }

    void FireBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
        else
        {
            if (bulletPrefab == null)
                Debug.LogWarning("�e�v���n�u (bulletPrefab) ���ݒ肳��Ă��܂���I");
            if (firePoint == null)
                Debug.LogWarning("���ˈʒu (firePoint) ���ݒ肳��Ă��܂���I");
        }
    }
}
