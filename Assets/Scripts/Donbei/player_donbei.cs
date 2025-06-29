using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public float speed = 1f;
    public GameObject bulletPrefab;    // �e�v���n�u�������Ŏw��
    protected Transform firePoint;        // �e���o��ʒu�������Ŏw��

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
        if (transform.position.x >= 10 && h > 0
        || transform.position.x <= -10 && h < 0)
        {
            h = 0;
        }

        if (transform.position.y >= 10 && v > 0
        || transform.position.y <= -4 && v < 0)
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
