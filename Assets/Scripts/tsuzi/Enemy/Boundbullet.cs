using UnityEngine;
using System.Collections;

public class Boundbullet : MonoBehaviour
{
    public Vector2 moveDirection; // Normalized direction
    public float speed = 5f;

    void Start()
    {
        StartCoroutine("ScaleDown");
        
    }

    void Update()
    {
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            // 壁の法線ベクトルを推定する（簡易的に）
            Vector2 normal = GetCollisionNormal(other);
            moveDirection = Vector2.Reflect(moveDirection, normal).normalized;
        }
    }

    // 法線ベクトルを推定（壁の向きに応じて変える）
    private Vector2 GetCollisionNormal(Collider2D wall)
    {
        Vector2 diff = transform.position - wall.transform.position;
        diff.Normalize();

        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
            return new Vector2(0, Mathf.Sign(diff.y));

        else
            return new Vector2(Mathf.Sign(diff.x), 0);
    }
    
     IEnumerator ScaleDown()
    {
        for ( float i = 1 ; i > 0 ; i-=0.02f ){
            this.transform.localScale = new Vector3(i,i,i);
            yield return new WaitForSeconds(0.1f);
        }
    }
}