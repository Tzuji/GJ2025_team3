using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float moveSpeed = 2f;               // 基本の進行速度（横）
    public float floatAmplitude = 0.5f;        // 上下の揺れ幅
    public float floatFrequency = 2f;          // 揺れの速さ
    public bool moveRight = true;              // true:右へ, false:左へ

    private float baseY;
    private float timeOffset;

    void Start()
    {
        baseY = transform.position.y;

        // 各敵ごとにランダムな振れ幅や速度にばらつきを加える
        floatAmplitude *= Random.Range(0.8f, 1.2f);
        floatFrequency *= Random.Range(0.8f, 1.2f);
        moveSpeed *= Random.Range(0.9f, 1.1f);

        timeOffset = Random.Range(0f, Mathf.PI * 2);
    }

    void Update()
    {
        float direction = moveRight ? 1f : -1f;
        float newX = transform.position.x + moveSpeed * direction * Time.deltaTime;
        float newY = baseY + Mathf.Sin(Time.time * floatFrequency + timeOffset) * floatAmplitude;

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
