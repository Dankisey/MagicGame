using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public class BiomesController : MonoBehaviour
    {
        [SerializeField] private PlayerBiomeHandler _playerBiomeHandler;
        [SerializeField] private EnemyViewFactory _enemyViewFactory;
        [SerializeField] private Biome _default;

        private readonly float _minChance = 0f;
        private readonly float _maxChance = 100f;

        private BattleState _currentBattle;
        private Biome _currentBiome;
        private Player _player;
        private World _world;
        private int _maxEnemiesInBattle;
        private float _battleChance;
        private float _timeElapsed;
        private float _tickTime;
        private bool _playerInBattle = false;

        public void Init(World world, Player player)
        {
            _player = player;
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
            int enemiesAmount = Random.Range(1, _maxEnemiesInBattle + 1);
            EnemyViewInitializer[] initializers = _currentBiome.GetRandomEnemies(enemiesAmount);
            _enemyViewFactory.SpawnEnemies(initializers, out Enemy[] enemies);
            _currentBattle = new(_player, enemies);
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