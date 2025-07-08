using UnityEngine;
namespace Donbei
{
    
public class Bullet : MonoBehaviour
{
    [Header("�e�̐ݒ�")]
    public float speed = 10f;        // �e�̑��x
    public float lifeTime = 3f;      // �����ŏ�����܂ł̎���

    private Vector3 direction = Vector3.up; // �f�t�H���g�̈ړ�������������ɕύX

    void Start()
    {
        // lifeTime �b��Ɏ����ō폜�����
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // direction �����Ɉړ�
        transform.Translate(Time.deltaTime*speed * direction);
    }

    /// <summary>
    /// �e�̐i�s�������O������ݒ肷��i�K�v�ɉ����āj
    /// </summary>
    /// <param name="dir">�ړ�����</param>
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }
}

}