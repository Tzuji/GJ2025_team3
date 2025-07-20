using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
namespace Donbei 
{
    public class Camera : MonoBehaviour
    {
        public GameObject playerObj;
        private Vector3 positionCache;
        // Start is called before the first frame update
        void Start()
        {
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
}
