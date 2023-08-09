using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    [CreateAssetMenu(fileName = "Biome", menuName = "Biome")]
    public class Biome : ScriptableObject
    {
        [SerializeField][Range(0, 3)] private int _maxEnemiesInBattle;
        [SerializeField][Range(0, 100)] private float _battleChance;
        [SerializeField] private EnemyViewInitializer[] _prefabs;
        [SerializeField] private float _tickTime;

        public int MaxEnemiesInBattle => _maxEnemiesInBattle;
        public float BattleChance => _battleChance;
        public float TickTime => _tickTime;

        public EnemyViewInitializer[] GetRandomEnemies(int amount)
        {
            EnemyViewInitializer[] randomEnemies = new EnemyViewInitializer[amount];

            for (int i = 0; i < amount; i++)
            {
                int randomValue = Random.Range(0, _prefabs.Length);
                randomEnemies[i] = _prefabs[randomValue];
            }

            return randomEnemies;
        }
    }
}