using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject bulletPrefab;

    public bool IsFollowing = true; // プレイヤーを追いかけるかどうか
    public float ShootingDistanceLimit = 10f; // 発射距離制限
    private GameObject player;
    private float time;

    void Start()
    {
        player = GameObject.Find("player_d");
        time = Time.deltaTime;
    }

    void Update()
    {
        if (IsFollowing)
        {
            Vector3 vector3 = player.transform.position - this.transform.position;
            vector3.z = 0;
            Quaternion quaternion = Quaternion.LookRotation(vector3);
            this.transform.rotation = quaternion;// プレイヤーの方向を向く
        }

        if (time > 2f //２秒に一回発射
        && Vector3.Distance(player.transform.position, transform.position) <= ShootingDistanceLimit)//かつ射程内にプレーヤーがいたら発射
        {
            Debug.Log("on");
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            time = Time.deltaTime;
        }
        time += Time.deltaTime;
    }
}
