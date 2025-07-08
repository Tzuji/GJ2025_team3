using UnityEngine;

namespace Donbei
{
    public class HomingPlayerBullet : MonoBehaviour
    {
        [Header("�e�̐ݒ�")] public float speed = 10f; // �e�̑��x
        public float lifeTime = 1.5f; // �����ŏ�����܂ł̎���
        public float rotateSpeed = 200f; // �e�̉�]���x
        private GameObject target; // �ǔ��Ώہi�G�j

// 呼び出し側
        private void Start()
        {
            Destroy(gameObject, lifeTime);
            target = FindNearestEnemy(transform.position);
        }

        private void Update()
        {
            // Y���W�� -5 �����������폜
            if (transform.position.y < -5f)
            {
                Destroy(gameObject);
                return;
            }

            if (target is null)
                //Debug.Log("defeated enemy");
                //target = FindNearestEnemy(transform.position);//����G��|�����Ƃ��ɒe���~�܂�Ȃ��悤�ɂ��邽�߂�
                return;

            try
            {
                var direction = (Vector2)target.transform.position - (Vector2)transform.position;
                direction.Normalize();

                var rotateAmount = Vector3.Cross(direction, transform.up).z;
                transform.Rotate(0, 0, -rotateAmount * rotateSpeed * Time.deltaTime);

                transform.Translate(speed * Time.deltaTime * Vector2.up);
            }
            catch (MissingReferenceException e)
            {
                Destroy(gameObject, 0.5f);
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name == "enemy_1" || other.CompareTag("Wall")) gameObject.SetActive(false);
        }

        private GameObject FindNearestEnemy(Vector3 fromPosition)
        {
            var enemyies = GameObject.FindGameObjectsWithTag("Enemy"); // �^�O���g�����������I
            GameObject nearest = null;
            var minDistance = Mathf.Infinity;
            if (enemyies.Length == 0) Destroy(gameObject);

            foreach (var enemy in enemyies)
            {
                var distance = Vector3.Distance(fromPosition, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = enemy;
                }
            }

            return nearest;
        }
    }
}