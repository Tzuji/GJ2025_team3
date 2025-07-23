using UnityEngine;

public class DelEnemy : MonoBehaviour
{
    public int point = 1;
    void OnTriggerEnter2D(Collider2D Collider)
    {
        Debug.Log("hitEnemy");
        if (Collider.gameObject.tag == "PlayerBullet")
        {
            Debug.Log("DestroyEnemy");
            GameManager.Instance.AddEnemyDefeated();
            GameManager.Instance.AddScore(point);
            Destroy(this.gameObject);
        }
    }
}
