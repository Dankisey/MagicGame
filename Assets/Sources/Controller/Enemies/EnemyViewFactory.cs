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

        public void DeleteEnemies()
        {
            foreach (var enemy in _spawned)           
                Destroy(enemy.gameObject);           
        }

        public void SpawnEnemies(EnemyViewInitializer[] prefabs, out Enemy[] enemies)
        {
            _spawned = new EnemyViewInitializer[prefabs.Length];
            enemies = new Enemy[prefabs.Length];

            for (int i = 0; i < enemies.Length; i++)
            {
                _spawned[i] = Instantiate(prefabs[i], spawnPoints[i]);
                Enemy enemy = _spawned[i].GetTargetEnemyInstance();
                _spawned[i].Init(enemy);
                enemies[i] = enemy;
            }

            EnemiesSpawned?.Invoke(GetCurrentViews());
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