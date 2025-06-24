using System.Collections;
using UnityEngine;

public class Drunkenlybullet : MonoBehaviour
{
    public float speed = 3f;
    public float waveFreq = 5f;
    public float waveAmp = 0.2f;

    [HideInInspector]
    public Vector2 moveDirection;  // ← 外部からセットされる
    private Vector2 perpendicular;
    private float timeCounter;

    void Start()
    {
        if (moveDirection == Vector2.zero)
            moveDirection = Vector2.down;

        perpendicular = new Vector2(-moveDirection.y, moveDirection.x);

        StartCoroutine(ScaleDown());
    }

    void Update()
    {
        timeCounter += Time.deltaTime;
        Vector2 waveOffset = perpendicular * Mathf.Sin(timeCounter * waveFreq) * waveAmp;
        Vector2 totalMove = (moveDirection * speed * Time.deltaTime) + waveOffset;

        transform.position += (Vector3)totalMove;
    }

    IEnumerator ScaleDown()
    {
        for (float i = 1; i > 0; i -= 0.02f)
        {
            transform.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);
    }
}
