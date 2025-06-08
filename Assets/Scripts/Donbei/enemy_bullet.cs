using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{
    public float speed = 2f;
    private float time = 0f;
    void Update()
    {
        time %= 360;
        time *= 6;
        speed = (float)(Math.Sin(time) + 1) * -20;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        time += 0.1f;
    }
}
