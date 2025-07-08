using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public Transform target;           // 追尾対象（プレイヤー）
    public float speed = 5f;           // 弾の移動速度
    public float rotateSpeed = 200f;   // 弾の回転速度

    void Update()
    {
        // Y座標が -5 を下回ったら削除
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
            return;
        }

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        transform.Rotate(0, 0, -rotateAmount * rotateSpeed * Time.deltaTime);

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // プレイヤーに当たったら弾を消すなどの処理
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
