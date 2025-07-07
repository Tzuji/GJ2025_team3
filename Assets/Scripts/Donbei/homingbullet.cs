using System.Collections;
using UnityEngine;

namespace Donbei
{
    public class HomingPlayerBullet : MonoBehaviour
    {
        private GameObject target; // �ǔ��Ώہi�G�j

        [Header("�e�̐ݒ�")] public float speed = 10f; // �e�̑��x
        public float lifeTime = 1.5f; // �����ŏ�����܂ł̎���
        public float rotateSpeed = 200f; // �e�̉�]���x

        IEnumerator DisableAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            gameObject.SetActive(false);
        }

// 呼び出し側
        void Start()
        {
            StartCoroutine(DisableAfterSeconds(lifeTime));
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

            if (target is null)
            {
                //Debug.Log("defeated enemy");
                //target = FindNearestEnemy(transform.position);//����G��|�����Ƃ��ɒe���~�܂�Ȃ��悤�ɂ��邽�߂�
                return;
            }

            try
            {

                Vector2 direction = (Vector2)target.transform.position - (Vector2)transform.position;
                direction.Normalize();

                float rotateAmount = Vector3.Cross(direction, transform.up).z;
                transform.Rotate(0, 0, -rotateAmount * rotateSpeed * Time.deltaTime);

                transform.Translate(speed * Time.deltaTime * Vector2.up);
            }
            catch (MissingReferenceException e)
            {
                Destroy(gameObject,0.5f);
            }
        }
        
        GameObject FindNearestEnemy(Vector3 fromPosition)
        {
            GameObject[] enemyies = GameObject.FindGameObjectsWithTag("Enemy"); // �^�O���g�����������I
            GameObject nearest = null;
            float minDistance = Mathf.Infinity;
            if (enemyies.Length == 0)
            {
                Destroy(gameObject);
            }

            foreach (GameObject enemy in enemyies)
            {
                float distance = Vector3.Distance(fromPosition, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = enemy;
                }
            }

            return nearest;
        }


        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name == "enemy_1" || other.CompareTag("Wall"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
