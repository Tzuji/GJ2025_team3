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
        time = (float)(((180 / freq) * time / Math.PI) % (180 * 360 / Math.PI));
        speed = -10 + (float)(Math.Sin(time)) * 9;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        time += 0.5f;
    }
}
