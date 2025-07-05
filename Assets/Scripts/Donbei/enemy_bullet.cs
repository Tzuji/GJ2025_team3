using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static System.MathF;

public class enemy_bullet : MonoBehaviour
{
    public float SpeedDecreace = 0.5f;
    public float freq = 1f;
    private GameObject targetObject;
    private float time = 0f;

    private Vector3 basePosition;
    private Vector3 direction;
    void Start()
    {
        targetObject = GameObject.Find("player_d");
        basePosition = transform.position;
        direction = new Vector3(basePosition.x - targetObject.transform.position.x, basePosition.y - targetObject.transform.position.y, 0f);
        direction *= SpeedDecreace;
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        float speed;
        float radian = PI / 180 * time * 360;
        // Debug.Log(radian);
        speed = -0.8f + Sin(radian * freq);
        transform.Translate(direction * speed * Time.deltaTime);
        time += Time.deltaTime;
    }
}