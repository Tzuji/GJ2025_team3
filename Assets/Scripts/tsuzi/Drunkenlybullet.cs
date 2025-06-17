using System.Collections;
using UnityEngine;

public class Drunkenlybullet : MonoBehaviour
{
    public float speed = 3f;
    public float waveFreq = 5f;
    public float waveAmp = 0.2f;

    private Transform target;
    public Vector2 moveDirection;
    private Vector2 perpendicular;
    private float timeCounter;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        target = player.transform;

        Vector2 dir = (target.position - transform.position).normalized;
        moveDirection = dir;
        perpendicular = new Vector2(-dir.y, dir.x);

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
