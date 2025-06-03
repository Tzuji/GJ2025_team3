using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float moveDistance = 3f;  // 移動距離
    public float moveSpeed = 2f;     // 移動スピード

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float move = moveSpeed * Time.deltaTime;
        if (movingRight)
        {
            transform.Translate(Vector2.right * move);
            if (transform.position.x >= startPosition.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector2.left * move);
            if (transform.position.x <= startPosition.x - moveDistance)
                movingRight = true;
        }
    }
}
