using UnityEngine;
namespace donbei
{
    
public class Bullet : MonoBehaviour
{
    [Header("弾の設定")]
    public float speed = 10f;        // 弾の速度
    public float lifeTime = 3f;      // 自動で消えるまでの時間

    private Vector3 direction = Vector3.up; // デフォルトの移動方向を上向きに変更

    void Start()
    {
        // lifeTime 秒後に自動で削除される
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // direction 方向に移動
        transform.Translate(direction * speed * Time.deltaTime);
    }

    /// <summary>
    /// 弾の進行方向を外部から設定する（必要に応じて）
    /// </summary>
    /// <param name="dir">移動方向</param>
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }
}

}