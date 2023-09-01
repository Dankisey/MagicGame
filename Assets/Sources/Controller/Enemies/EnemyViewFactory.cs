using UnityEngine;
using Game.Model;
using Game.View; 
using System;

namespace Game.Controller
{
    public class EnemyViewFactory : MonoBehaviour
    {
        [SerializeField] private EnemyViewInitializer[] _enemies;
        [SerializeField] private Transform[] spawnPoints;

        private EnemyViewInitializer[] _spawned;

        public event Action<EnemyView[]> EnemiesSpawned;

        public void SpawnEnemies(EnemyModelContainer[] prefabs, int minLevel, int maxLevel, out Enemy[] enemies)
        {
            if (_spawned != null)
                DeleteEnemies();

            _spawned = new EnemyViewInitializer[prefabs.Length];
            enemies = new Enemy[prefabs.Length];

            for (int i = 0; i < enemies.Length; i++)
            {
                _spawned[i] = Instantiate(prefabs[i].ViewInitializer, spawnPoints[i]);
                int enemyLevel = UnityEngine.Random.Range(minLevel, maxLevel + 1);
                Enemy enemy = prefabs[i].GetTargetEnemyInstance(enemyLevel);
                _spawned[i].Init(enemy);
                enemies[i] = enemy;
            }

            EnemiesSpawned?.Invoke(GetCurrentViews());
        }

        private void DeleteEnemies()
        {
            foreach (var enemy in _spawned)           
                Destroy(enemy.gameObject);           
        }

        private EnemyView[] GetCurrentViews()
        {
            EnemyView[] views = new EnemyView[_spawned.Length];

            for (int i = 0; i < _spawned.Length; i++)
            {
                views[i] = _spawned[i].View;
            }
            
            return views;
        }
    }
}