using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 1f;
    public GameObject bulletPrefab;    // �e�v���n�u�������Ŏw��
    private Transform firePoint;        // �e���o��ʒu�������Ŏw��

    private float time;
    void Start()
    {
        time = Time.deltaTime;
        firePoint = this.transform;
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(h, v, 0);
        transform.position += movement * speed * Time.deltaTime;
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && time > 1f)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            time = Time.deltaTime;
        }

    }
}
