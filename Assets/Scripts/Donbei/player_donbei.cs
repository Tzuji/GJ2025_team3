using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Camera;
public class Controller : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public float speed = 1f;
    public GameObject bulletPrefab;
    private static GameObject _bulletPrefab;    // 弾プレハブをここで指定
    protected Transform firePoint;        // 弾が出る位置をここで指定
    protected float time;
    private const string Normal_path = "Assets/Prefab/PlayerBullet.prefab";
    private const string Homing_path = "Assets/Prefab/player_homig 1.prefab";
    private Camera mainCamera;
    private static float shootInterval = 0.1f;

    private List<GameObject> bulletPool= new(12); 

    public void ChangeNormalBullet()
    {
        _bulletPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(Normal_path);
        SceneManager.LoadScene("donbei");//TODO: 直接donbeiステージに行くので後々StartMenuに戻るように直す
    }

    public void ChangeHomingBullet()
    {
        _bulletPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(Homing_path);
        SceneManager.LoadScene("donbei");//TODO: 直接donbeiステージに行くので後々StartMenuに戻るように直す
        shootInterval = 0.2f;
    }

    void Start()
    {
        time = Time.deltaTime;
        firePoint = this.transform;
        mainCamera = Camera.main;
        if (_bulletPrefab != null)
        {
            bulletPrefab = _bulletPrefab;
        }
        PoolBullet(10);
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float ViewPortX = mainCamera.WorldToViewportPoint(transform.position).x;
        float ViewPortY = mainCamera.WorldToViewportPoint(transform.position).y;
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
        transform.position += speed * Time.deltaTime*movement;
        time += Time.deltaTime;


        if (Input.GetKey(KeyCode.Space) && time > shootInterval)
        {
            //Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);//XXX: 弾の連射速度が早いとき重いのでオブジェクトプールにしたいところ
            ShootBullet();
            time = Time.deltaTime;

            animator.SetBool("Attack", true);
        }
        else if (animator.GetBool("Attack"))
        {
            animator.SetBool("Attack", false);
        }
    }

    private void ShootBullet()//オブジェクトプールしつつ弾を発射するメソッド
    {
        PoolBullet(2);
        CallBullet();
    }


    private void PoolBullet(int amount)
    {
        //if (bulletPool.Count >index) return;
        if (bulletPool.Count > 0) return;
        for (int i = 0; i < amount; i++)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab,Vector3.zero, Quaternion.identity);
            bulletInstance.SetActive(false);
            bulletPool.Add(bulletInstance);
        }
    }

    private int index = 0;
    private void CallBullet()
    {
        bulletPool[0].transform.position = firePoint.position;
        bulletPool[0].SetActive(true);
        bulletPool.RemoveAt(0);
        //index = ++index % bulletPool.Count;
    }
}
