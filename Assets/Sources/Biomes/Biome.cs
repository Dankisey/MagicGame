using UnityEngine;

namespace Game.Controller
{
    [CreateAssetMenu(fileName = "Biome", menuName = "Biome")]
    public class Biome : ScriptableObject
    {
        [SerializeField][Range(0, 3)] private int _maxEnemiesInBattle;
        [SerializeField][Range(0, 100)] private float _battleChance;
        [SerializeField] private int _minEnemyLevel;
        [SerializeField] private int _maxEnemyLevel;
        [SerializeField] private EnemyModelContainer[] _prefabs;
        [SerializeField] private float _tickTime;

        public int MaxEnemiesInBattle => _maxEnemiesInBattle;
        public int MinEnemyLevel => _minEnemyLevel;
        public int MaxEnemyLevel => _maxEnemyLevel;
        public float BattleChance => _battleChance;
        public float TickTime => _tickTime;

        public EnemyModelContainer[] GetRandomEnemies(int amount)
        {
            EnemyModelContainer[] randomEnemies = new EnemyModelContainer[amount];

            for (int i = 0; i < amount; i++)
            {
                int randomValue = Random.Range(0, _prefabs.Length);
                randomEnemies[i] = _prefabs[randomValue];
            }

            return randomEnemies;
        }
    }
}