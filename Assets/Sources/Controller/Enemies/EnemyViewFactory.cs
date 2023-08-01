using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Game.Model;
using System;

namespace Game.Controller
{
    public class EnemyViewFactory : MonoBehaviour
    {
        [SerializeField] private EnemyInitializer[] _enemies;
        [SerializeField] private Transform _parent;

        private Battle _currentBattle;
        private World _world;

        public void Init(World world)
        {
            _world = world;
            _world.BattleInitiated += OnBattleInitiated;
        }

        private void OnBattleInitiated(Battle battle)
        {
            _currentBattle = battle;
            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            Enemy[] enemies = _currentBattle.GetEnemies();

            foreach (Enemy enemy in enemies)
            {
                EnemyInitializer initializer = GetEnemy(enemy.ID);
                initializer = Instantiate(initializer, _parent);
                initializer.Init(enemy);
            }
        }

        private EnemyInitializer GetEnemy(EnemyIDs id)
        {
            IEnumerable<EnemyInitializer> enemies = _enemies.Where(enemy => enemy.ID == id);
            EnemyInitializer enemy = enemies.FirstOrDefault();

            if (enemy == null)
                throw new InvalidOperationException("EnemyView with id " + id + " not found");

            return enemy;
        }

        private void OnDisable()
        {
            if (_world != null)
                _world.BattleInitiated -= OnBattleInitiated;
        }
    }
}