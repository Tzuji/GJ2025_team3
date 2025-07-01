using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Camera;
public class Controller : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public float speed = 1f;
    public GameObject bulletPrefab;    // 弾プレハブをここで指定
    protected Transform firePoint;        // 弾が出る位置をここで指定

    protected float time;
    void Start()
    {
        time = Time.deltaTime;
        firePoint = this.transform;
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float ViewPortX = /*Camera.*/main.WorldToViewportPoint(transform.position).x;
        float ViewPortY = /*Camera.*/main.WorldToViewportPoint(transform.position).y;
        if (ViewPortX > 1 && h > 0
        || ViewPortX < 0 && h < 0)
        {
            h = 0;
        }

        if (ViewPortY > 0.85 && v > 0
        || ViewPortY < 0.15 && v < 0)
        {
            v = 0;
        }
        Vector3 movement = new Vector3(h, v, 0);
        transform.position += movement * speed * Time.deltaTime;
        time += Time.deltaTime;


        if (Input.GetKey(KeyCode.Space) && time > 0.2f)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            time = Time.deltaTime;

            animator.SetBool("Attack", true);
        }
        else if (animator.GetBool("Attack"))
        {
            animator.SetBool("Attack", false);
        }
    }
}
