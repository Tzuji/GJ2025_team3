using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject playerObj;
    private Vector3 positionCache;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("player");
        positionCache = new(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        positionCache.x = playerObj.transform.position.x;
        positionCache.y = playerObj.transform.position.y + 2;
        this.transform.position = positionCache;
    }
}
