using UnityEngine;

public class HomingPlayerBullet : MonoBehaviour
{
    private GameObject target;           // �ǔ��Ώہi�G�j

    [Header("�e�̐ݒ�")]
    public float speed = 10f;        // �e�̑��x
    public float lifeTime = 3f;      // �����ŏ�����܂ł̎���
    public float rotateSpeed = 200f;   // �e�̉�]���x

    void Start()
    {
        Destroy(gameObject, lifeTime);
        target = GameObject.Find("kernel");
    }

    void Update()
    {
        // Y���W�� -5 �����������폜
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
            // �v���C���[�ɓ���������e�������Ȃǂ̏���
            Destroy(gameObject);
        }
    }
}
