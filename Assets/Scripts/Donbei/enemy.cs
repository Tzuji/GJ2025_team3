using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject player;
    private float time;
    void Start()
    {
        player = GameObject.Find("player");
        time = Time.deltaTime;
    }

    void Update()
    {
        Vector3 vector3 = player.transform.position - this.transform.position;
        vector3.z = 0;
        //vector3.x = 0;
        //vector3.y = 0;
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        this.transform.rotation = quaternion;

        if (time > 2f)//２秒に一回発射
        {
            Debug.Log("on");
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            time = Time.deltaTime;
        }
        time += Time.deltaTime;

    }
}
