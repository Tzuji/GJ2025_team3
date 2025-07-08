using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public Transform target;           // �ǔ��Ώہi�v���C���[�j
    public float speed = 5f;           // �e�̈ړ����x
    public float rotateSpeed = 200f;   // �e�̉�]���x

    void Update()
    {
        // Y���W�� -5 �����������폜
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
            // �v���C���[�ɓ���������e�������Ȃǂ̏���
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
