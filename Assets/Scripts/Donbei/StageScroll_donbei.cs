using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScroll_donbei : MonoBehaviour
{
    [Header("倒すとスクロールする敵達")]
    public List<GameObject> ScrollTriggerEnemys;
    [Header("スクロールする方向")]
    public List<Vector3> ScrollDirections;
    public float scrollingTime = 2f;
    private float time=0;

    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!ScrollTriggerEnemys[0].activeSelf)
        {
            playerTransform.position += ScrollDirections[0] * Time.deltaTime / scrollingTime;
            transform.position += ScrollDirections[0] * Time.deltaTime / scrollingTime;
            time += Time.deltaTime;
            if (scrollingTime < time)
            {
                time = 0;
                ScrollTriggerEnemys.RemoveAt(0);
                ScrollDirections.RemoveAt(0);
            }
        }
    }
}
