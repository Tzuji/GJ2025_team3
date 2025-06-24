using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public GameObject bulletPrefab;    // 弾プレハブ（Inspectorで設定）
    public Transform firePoint;        // 弾が出る位置（Inspectorで設定）

    void Update()
    {
        // プレイヤーの移動
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(h, v, 0);
        transform.position += movement * speed * Time.deltaTime;

        // スペースキーで弾を発射
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
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
