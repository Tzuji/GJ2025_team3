using System.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public int roop = 5;
    public float second = 1.0f;
    private bool hasSpawned = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasSpawned)
        {
            hasSpawned = true;
            StartCoroutine(SpawnEnemies());
        }

        IEnumerator SpawnEnemies()
        {
            for (int i = 0; i < roop; i++)
            {
                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(second);
            }
        }
    }
}
