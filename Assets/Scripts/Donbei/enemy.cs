using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject bulletPrefab;

    public bool IsFollowing = true; // プレイヤーを追いかけるかどうか
    public float ShootingDistanceLimit = 10f; // 発射距離制限
    private GameObject player;
    private float time;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        time = Time.deltaTime;
    }

    private void Update()
    {
        if (player is null) return;

        try
        {
            if (IsFollowing)
            {
                var vector3 = player.transform.position - transform.position;
                vector3.z = 0;
                var quaternion = Quaternion.LookRotation(vector3);
                transform.rotation = quaternion; // プレイヤーの方向を向く
            }

            if (time > 2f //２秒に一回発射
                && Vector3.Distance(player.transform.position, transform.position) <=
                ShootingDistanceLimit) //かつ射程内にプレーヤーがいたら発射
            {
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                time = Time.deltaTime;
            }

            time += Time.deltaTime;
        }
        catch (MissingReferenceException e)
        {
            Debug.Log("player dead");
        }
    }
}

public static class _Enemy
{
    public static GameObject _player;
}