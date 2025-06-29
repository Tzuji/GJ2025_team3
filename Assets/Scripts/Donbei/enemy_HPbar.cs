using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy_HPbar : MonoBehaviour
{
    private Transform parent_trans;
    public float y_diff;
    private int hp_max;
    [SerializeField]
    private enemy_hit EnemyHitScript;
    // Start is called before the first frame update
    void Start()
    {
        parent_trans = transform.parent.transform;
        Vector3 BarPosition = new(parent_trans.position.x, parent_trans.position.y - y_diff, 0);
        this.transform.position = BarPosition;
        this.transform.eulerAngles = new Vector3(0, 0, 0);
        hp_max = EnemyHitScript.HP;
    }

    void Update()
    {
        int hp = EnemyHitScript.HP;
        this.transform.localScale = new Vector3(hp / (float)hp_max, 2, 0);
    }
}
