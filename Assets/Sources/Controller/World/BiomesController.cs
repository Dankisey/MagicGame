using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public class BiomesController : MonoBehaviour
    {
        [SerializeField] private PlayerBiomeHandler _playerBiomeHandler;
        [SerializeField] private Biome _default;

        private readonly float _minChance = 0f;
        private readonly float _maxChance = 100f;

        private BattleState _currentBattle;
        private Biome _currentBiome;
        private World _world;
        private int _maxEnemiesInBattle;
        private float _battleChance;
        private float _timeElapsed;
        private float _tickTime;
        private bool _playerInBattle = false;

        public void Init(World world)
        {
            _world = world;      
        }

        private void OnNewBiomeEntered(Biome biome)
        {
            _currentBiome = biome;
            _maxEnemiesInBattle = biome.MaxEnemiesInBattle;
            _battleChance = biome.BattleChance;
            _tickTime = biome.TickTime;
            _timeElapsed = 0;
        }

        private void OnBiomeExited()
        {
            _currentBiome = _default;
            _maxEnemiesInBattle = _default.MaxEnemiesInBattle;
            _battleChance = _default.BattleChance;
            _tickTime = _default.TickTime;
            _timeElapsed = 0;
        }

        private void OnBattleEnded()
        {
            _currentBattle.Ended -= OnBattleEnded;
            _playerInBattle = false;
            _timeElapsed = 0;
        }

        private void InitBattle()
        {
            int enemiesAmount = Random.Range(0, _maxEnemiesInBattle + 1);
            Enemy[] enemies = _currentBiome.GetRandomEnemies(enemiesAmount);
            _currentBattle = new(Player.Instance, enemies);
            _currentBattle.Ended += OnBattleEnded;
            _playerInBattle = true;
            _world.EnterBattle(_currentBattle);
        }

        private bool TryInitBattle()
        {
            float randomValue = Random.Range(_minChance, _maxChance);
            bool succeeded = randomValue < _battleChance;

            if (succeeded)
            {
                InitBattle();
                _timeElapsed = 0;
            }

            return succeeded;
        }

        private void Update() 
        {
            if(_playerInBattle == false) 
            {
                _timeElapsed += Time.deltaTime;

                if (_timeElapsed >= _tickTime)               
                    TryInitBattle();                
            }       
        }

        private void OnEnable()
        {
            _playerBiomeHandler.NewBiomeEntered += OnNewBiomeEntered;
            _playerBiomeHandler.BiomeExited += OnBiomeExited;
            _currentBiome = _default;
        }

        private void OnDisable()
        {
            _playerBiomeHandler.NewBiomeEntered -= OnNewBiomeEntered;
            _playerBiomeHandler.BiomeExited -= OnBiomeExited;
        }
    }
}