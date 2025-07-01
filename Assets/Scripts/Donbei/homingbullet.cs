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
        target = FindNearestEnemy(transform.position);
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
            //Debug.Log("defeated enemy");
            //target = FindNearestEnemy(transform.position);//����G��|�����Ƃ��ɒe���~�܂�Ȃ��悤�ɂ��邽�߂�
            return;
        }

        Vector2 direction = (Vector2)target.transform.position - (Vector2)transform.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        transform.Rotate(0, 0, -rotateAmount * rotateSpeed * Time.deltaTime);

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    GameObject FindNearestEnemy(Vector3 fromPosition)
    {
        GameObject[] kernels = GameObject.FindGameObjectsWithTag("Enemy"); // �^�O���g�����������I
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;
        if (kernels.Length == 0)
        {
            Destroy(gameObject);
        }
        foreach (GameObject kernel in kernels)
        {
            float distance = Vector3.Distance(fromPosition, kernel.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = kernel;
            }
        }

        return nearest;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "enemy_1")
        {
            // �G�ɓ���������e�������Ȃǂ̏���
            Destroy(gameObject);
        }
    }
}
