using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnerManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _enemiesPrefabs;

    [SerializeField]
    private float _spawnInterval = 3.5f;
    private float _defaultSpawnInterval;

    [SerializeField]
    private float _damageMultiplier = 1f;
    private float _defaultDamageMultiplier;

    [SerializeField]
    private float _hpMultiplier = 1f;
    private float _defaultHpMultiplier;

    private float _spawnTimer = 0f;

    private List<Vector3> _spawnPositions;

    private List<GameObject> _spawnedEnemies;

    public void Awake()
    {
        _spawnPositions = new List<Vector3>();
        _spawnedEnemies = new List<GameObject>();

        foreach (Transform child in transform)
        {
            _spawnPositions.Add(child.position);
        }
    }

    public void Start()
    {
        _defaultSpawnInterval = _spawnInterval;
        _defaultDamageMultiplier = _damageMultiplier;
        _defaultHpMultiplier = _hpMultiplier;
    }

    public void Update()
    {
        if (Time.time > _spawnTimer)
        {
            SpawnEnemies();
            _spawnTimer = Time.time + _spawnInterval;
        }
        CheckEnemiesLife();
    }
    
    private void CheckEnemiesLife()
    {
        for (int i = _spawnedEnemies.Count - 1; i >= 0; i--)
        {
            if (_spawnedEnemies[i] == null)
            {
                _spawnedEnemies.RemoveAt(i);
            }
        }
    }

    private void SpawnEnemies()
    {
        foreach (var spawnPosition in _spawnPositions)
        {
            int randomEnemyIndex = Random.Range(0, _enemiesPrefabs.Count);
            var enemy = Instantiate(_enemiesPrefabs[randomEnemyIndex], spawnPosition, Quaternion.identity);

            enemy.GetComponent<Enemy>().Damage *= _damageMultiplier;
            enemy.GetComponent<EnnemyLifeController>().Health *= _hpMultiplier;

            _spawnedEnemies.Add(enemy);
        }
    }

    public void Reset()
    {
        foreach (var enemy in _spawnedEnemies)
        {
            Destroy(enemy);
        }
        _spawnedEnemies.Clear();
        
        _spawnInterval = _defaultSpawnInterval;
        _damageMultiplier = _defaultDamageMultiplier;
        _hpMultiplier = _defaultHpMultiplier;
    }

    public void IncreaseDifficulty()
    {
        _spawnInterval *= 0.85f;

        _damageMultiplier += 0.25f;
        _hpMultiplier += 0.25f;
    }
}
