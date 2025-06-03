using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public GameObject bulletPrefab;    // 弾プレハブをここで指定
    public Transform firePoint;        // 弾が出る位置をここで指定

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(h, v, 0);
        transform.position += movement * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            //Destroy(bulletPrefab);
        }
    }
}
