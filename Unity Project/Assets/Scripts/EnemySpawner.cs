using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private BoxCollider2D spawnPlatform;

    // Start is called before the first frame update
    void Start()
    {
    }

    public IEnumerator Spawner(int numEnemies) {
        WaitForSeconds wait = new WaitForSeconds(GameManager.gameManager.spawnRate);

        yield return new WaitForSeconds(Random.Range(0f, 2f));
        for (int i = 0; i < numEnemies; i++) {
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
