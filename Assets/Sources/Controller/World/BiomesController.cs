using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public class BiomesController : MonoBehaviour
    {
        [SerializeField] private Biome _default;

        private PlayerBiomeHandler _playerBiomeHandler;
        private Biome _currentBiome;
        private World _world;
        private int _maxEnemiesInBattle;
        private float _battleChance;
        private float _timeElapsed;
        private float _tickTime;
        private readonly float _minChance = 0f;
        private readonly float _maxChance = 100f;

        public void Init(PlayerBiomeHandler biomeHandler, World world)
        {
            _world = world;
            _playerBiomeHandler = biomeHandler;
            _playerBiomeHandler.NewBiomeEntered += OnNewBiomeEntered;          
        }

        private void OnNewBiomeEntered(Biome biome)
        {
            _currentBiome = biome;
            _maxEnemiesInBattle = biome.MaxEnemiesInBattle;
            _battleChance = biome.BattleChance;
            _tickTime = biome.TickTime;
            _timeElapsed = 0;
        }

        private void InitBattle()
        {
            int enemiesAmount = Random.Range(0, _maxEnemiesInBattle + 1);
            Enemy[] enemies = _currentBiome.GetRandomEnemies(enemiesAmount);
            BattleState battle = new(Player.Instance, enemies);
            _world.EnterBattle(battle);
        }

        private void Start()
        {
            _currentBiome = _default;
        }

        private void Update() 
        {
            _timeElapsed += Time.deltaTime;

            if (_timeElapsed >= _tickTime)
            {
                float randomValue = Random.Range(_minChance, _maxChance);

                if (randomValue < _battleChance)
                {
                    InitBattle();
                    _timeElapsed = 0;
                }
            }
        }
    }
}