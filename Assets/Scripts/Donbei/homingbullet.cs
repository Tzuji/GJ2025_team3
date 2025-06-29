using UnityEngine;

public class HomingPlayerBullet : MonoBehaviour
{
    private GameObject target;           // ’Ç”ö‘ÎÛi“Gj

    [Header("’e‚Ìİ’è")]
    public float speed = 10f;        // ’e‚Ì‘¬“x
    public float lifeTime = 3f;      // ©“®‚ÅÁ‚¦‚é‚Ü‚Å‚ÌŠÔ
    public float rotateSpeed = 200f;   // ’e‚Ì‰ñ“]‘¬“x

    void Start()
    {
        Destroy(gameObject, lifeTime);
        target = GameObject.Find("kernel");
    }

    void Update()
    {
        // YÀ•W‚ª -5 ‚ğ‰º‰ñ‚Á‚½‚çíœ
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
            return;
        }

        if (!target.activeSelf)
        {
            Debug.Log("defeated enemy");
            target = GameObject.Find("kernel");
            return;
        }

        Vector2 direction = (Vector2)target.transform.position - (Vector2)transform.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        transform.Rotate(0, 0, -rotateAmount * rotateSpeed * Time.deltaTime);

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "enemy_1")
        {
            // ƒvƒŒƒCƒ„[‚É“–‚½‚Á‚½‚ç’e‚ğÁ‚·‚È‚Ç‚Ìˆ—
            Destroy(gameObject);
        }
    }
}
