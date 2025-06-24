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
            Debug.LogError("Rigidbody2D がアタッチされていません！");
        }
    }

    void Update()
    {
        // 入力取得（方向のみ）
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        movementInput = new Vector2(h, v);

        // 弾発射
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void FixedUpdate()
    {
        // 物理ベースで移動（当たり判定有効）
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
                Debug.LogWarning("弾プレハブ (bulletPrefab) が設定されていません！");
            if (firePoint == null)
                Debug.LogWarning("発射位置 (firePoint) が設定されていません！");
        }
    }
}
