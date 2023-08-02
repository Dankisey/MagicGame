using UnityEngine;
using Game.Model;
using Game.View;

namespace Game.Controller
{
    [CreateAssetMenu(fileName = "Biome", menuName = "Biome")]
    public class Biome : ScriptableObject
    {
        [SerializeField] private EnemyView[] _enemyPrefabs;
        [SerializeField][Range(0, 100)] private float _battleChance;
        [SerializeField] private float _tickTime;
        [SerializeField] private int _maxEnemiesInBattle;

        private Enemy[] _enemies = null;

        public int MaxEnemiesInBattle => _maxEnemiesInBattle;
        public float BattleChance => _battleChance;
        public float TickTime => _tickTime;

        public Enemy[] GetRandomEnemies(int amount)
        {
            if (_enemies == null)
                _enemies = GetEnemies();

            Enemy[] enemies = new Enemy[amount];

            for (int i = 0; i < amount; i++)
            {
                int randomValue = Random.Range(0, _enemies.Length); 
                Enemy enemy = _enemies[randomValue];

                enemies[i] = enemy.GetNewInstance();
            }

            return enemies;
        }

        private Enemy[] GetEnemies()
        {
            Enemy[] enemies = new Enemy[_enemyPrefabs.Length];

            for (int i = 0; i < enemies.Length; i++)
                enemies[i] = _enemyPrefabs[i].Self;
            
            return enemies;
        }
    }
}