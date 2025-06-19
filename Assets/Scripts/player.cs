using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public GameObject bulletPrefab;    // �e�v���n�u�������Ŏw��
    public Transform firePoint;        // �e���o��ʒu�������Ŏw��

    private float time;
    void Start()
    {
        time = Time.deltaTime;
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(h, v, 0);
        transform.position += movement * speed * Time.deltaTime;
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && time > 2f)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            time = Time.deltaTime;
        }

    }
}
