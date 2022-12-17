using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager _instance;

    private static readonly object locker = new object();

    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private Stopwatch _stopwatch;

    [SerializeField]
    private XpDropper _xpDropper;

    [SerializeField]
    private XpManager _xpManager;

    [SerializeField]
    private EnemiesSpawnerManager _enemiesSpawnerManager;

    [SerializeField]
    private float _gameDifficultyIncreaserDelay = 15f;

    private float _gameTimerCheckPoint = 0f;

    public static GameManager Instance()
    {
        lock (locker)
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(GameManager).Name;
                    _instance = go.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    public void Update()
    {
        if (_stopwatch.CurrentTime - _gameDifficultyIncreaserDelay >= _gameTimerCheckPoint)
        {
            _gameTimerCheckPoint += _gameDifficultyIncreaserDelay;
            _enemiesSpawnerManager.IncreaseDifficulty();
        }
    }

   
    public void Reset()
    {
        _playerController.Reset();
        _stopwatch.ResetStopWatch();
        _enemiesSpawnerManager.Reset();
        _xpDropper.Reset();
        _xpManager.Reset();
    }
}
