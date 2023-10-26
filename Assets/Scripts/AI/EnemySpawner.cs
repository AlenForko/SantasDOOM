using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;

namespace AI
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private GameObject[] _enemyPrefabs;

        private int _spawnCount;
        private int _spawnIndex;

        private GameObject[] spawnedEnemies;

        public bool EnemiesActive()
        {
            return spawnedEnemies.Any((a) => { return a != null; }) || spawnedEnemies.Length == 0;
        }

        private void Start()
        {
            _spawnCount = transform.childCount;
            _spawnPoints = new Transform[_spawnCount];
            spawnedEnemies = new GameObject[_spawnCount];

            for (int i = 0; i < _spawnCount; i++)
            {
                int randomEnemy = Random.Range(0, _enemyPrefabs.Length);
                
                _spawnPoints[i] = transform.GetChild(i);
                spawnedEnemies[i] = Instantiate(_enemyPrefabs[randomEnemy], _spawnPoints[i].position,
                    _enemyPrefabs[randomEnemy].transform.rotation);
            }
        }
    }
}
