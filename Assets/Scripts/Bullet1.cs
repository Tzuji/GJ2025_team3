using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            // ƒvƒŒƒCƒ„[‚ÌHP‚ğŒ¸‚ç‚·ˆ—‚È‚Ç
        }
    }
}
