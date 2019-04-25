using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    private float _spawnTime;
    private float _spawnTimer;
    private int _countPrefabs;
    private GameObject _prefab;
    private bool _spawn = false;

    public void StartSpawner(GameObject prefab, int countPrefabs, float spawnTime)
    {
        _prefab = prefab;
        _countPrefabs = countPrefabs;
        _spawnTime = spawnTime;
        _spawnTimer = 0f;
        _spawn = true;
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0f && _spawn)
        {
            _spawnTimer += _spawnTime;
            if (_countPrefabs > 0)
            {
                if (_prefab != null)
                {
                    _prefab = Instantiate(_prefab, transform.position, transform.rotation);
                    GameManager.Instance.AddEnemy();
                }
                _countPrefabs--;
            }
            else
                Destroy(gameObject);
        }
    }


}
