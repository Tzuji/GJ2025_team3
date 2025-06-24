using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public GameObject bulletPrefab;    // �e�v���n�u�iInspector�Őݒ�j
    public Transform firePoint;        // �e���o��ʒu�iInspector�Őݒ�j

    void Update()
    {
        // �v���C���[�̈ړ�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(h, v, 0);
        transform.position += movement * speed * Time.deltaTime;

        // �X�y�[�X�L�[�Œe�𔭎�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
        else
        {
            if (bulletPrefab == null)
                Debug.LogWarning("�e�v���n�u (bulletPrefab) ���ݒ肳��Ă��܂���I");
            if (firePoint == null)
                Debug.LogWarning("���ˈʒu (firePoint) ���ݒ肳��Ă��܂���I");
        }
    }
}
