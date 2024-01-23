using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;

    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private BoxCollider2D spawnPlatform;

    private bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner() {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn) {
            yield return wait;
            Instantiate(spawnPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        }
    }

    private Vector2 GetRandomSpawnPosition()
    {
        Vector2 randomPoint = new Vector2(
            Random.Range(spawnPlatform.bounds.min.x, spawnPlatform.bounds.max.x),
            Random.Range(spawnPlatform.bounds.min.y, spawnPlatform.bounds.max.y)
        );

        return randomPoint;
    }
}
