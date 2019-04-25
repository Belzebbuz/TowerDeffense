using UnityEngine;

[CreateAssetMenu]
public class LevelConfig : ScriptableObject
{
    [System.Serializable]
    public struct Wave
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject[] spawnPoints;
        public int countEnemy;
        public float spawnTime;

        public GameObject EnemyPrefab { get { return enemyPrefab; } }
        public GameObject[] SpawnPoints { get { return spawnPoints; } }
    }
    public Wave[] waves;
}
