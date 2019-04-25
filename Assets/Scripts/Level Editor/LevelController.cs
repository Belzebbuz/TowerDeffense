using UnityEngine;
using System;

public class LevelController : MonoBehaviour {

    [SerializeField] private LevelConfig _levelConfig;
    private GameObject[] _spawnPoints;
    private GameObject _enemyPrefab;
    private int _countEnemy;
    private float _spawnTime;

    public Action<LevelController> NextWaveEvent;
    public int CurrentWaveIndex { get; private set; }
    public int MaxWave { get; private set; }

    private void Awake()
    {
        CurrentWaveIndex = 0;
        if (_levelConfig != null)
            MaxWave = _levelConfig.waves.Length;
    }

    private void LateUpdate()
    {
        if (GameManager.Instance.CurrentCountEnemy == 0)
        {
            if (CurrentWaveIndex == _levelConfig.waves.Length)
            {
                GameManager.Instance.Victory();
            }
            else
            {
                InitCurrentWave(CurrentWaveIndex);
                NextWave();
            }
        }
    }

    private void InitCurrentWave(int currentWaveIndex)
    {
        if (_levelConfig != null)
        {
            _enemyPrefab = _levelConfig.waves[currentWaveIndex].EnemyPrefab;
            _countEnemy = _levelConfig.waves[currentWaveIndex].countEnemy;
            _spawnTime = _levelConfig.waves[currentWaveIndex].spawnTime;
            InstantiateSpawnPoints(currentWaveIndex, _enemyPrefab, _countEnemy, _spawnTime);
        }
    }

    private void InstantiateSpawnPoints(int currentWaveIndex, GameObject enemyPrefab,int countEnemy, float spawnTime)
    {
        _spawnPoints = _levelConfig.waves[currentWaveIndex].SpawnPoints;
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            var spawner = Instantiate(_spawnPoints[i], transform).GetComponent<EnemySpawner>();
            if (spawner != null)
                spawner.StartSpawner(enemyPrefab, countEnemy, spawnTime);
            else
                Destroy(spawner);
        }
    }

    private void NextWave()
    {
        if (CurrentWaveIndex < _levelConfig.waves.Length)
        { 
            if (NextWaveEvent != null)
                NextWaveEvent(this);
            CurrentWaveIndex++;
        }
    }
}
