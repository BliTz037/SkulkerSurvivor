using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;

    [SerializeField]
    private float _spawnInterval = 3.5f;

    void Start()
    {
        StartCoroutine(SpawnEnemy(_spawnInterval, _enemy));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        while (true)
        {
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }
}
