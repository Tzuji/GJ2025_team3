using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{
    public float speed = 2f;

    public float freq = 1f;

    private float time = 0f;

    void Update()
    {
        float radian = (float)(Math.PI / 180 * time * 360);
        Debug.Log(radian);
        speed = -10 + (float)(Math.Sin(radian * freq)) * 9;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        time += Time.deltaTime;
    }
}
