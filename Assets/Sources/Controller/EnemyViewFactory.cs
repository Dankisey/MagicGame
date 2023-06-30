using System.Collections.Generic;
using UnityEngine;
using Game.Model;

namespace Game.View
{
    public class EnemyViewFactory : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private EnemyIDs[] _ids;
        [SerializeField] private EnemyView _template;
        [SerializeField] private Transform _parent;

        private Dictionary<EnemyIDs, Sprite> _enemies;
        private Battle _currentBattle;
        private World _world;

        public void Init(World world)
        {
            _world = world;
            _world.BattleInitiated += OnBattleInitiated;
            InitDictionary();
        }

        private void InitDictionary()
        {
            _enemies = new Dictionary<EnemyIDs, Sprite>();

            for (int i = 0; i < _sprites.Length; i++)
                _enemies.Add(_ids[i], _sprites[i]);
        }

        private void OnValidate()
        {
            if (_sprites.Length != _ids.Length)           
                Debug.LogWarning($"{nameof(_sprites)}.Length != {nameof(_ids)}.Length");   
        }

        private void OnBattleInitiated(Battle battle)
        {
            _currentBattle = battle; 
            InitEnemyViews();
        }

        private void InitEnemyViews()
        {
            Enemy[] enemies = _currentBattle.GetEnemies();
            EnemyView[] enemiesView = new EnemyView[enemies.Length];

            for (int i = 0; i < enemies.Length; i++)
            {
                EnemyView enemyView = Instantiate(_template, _parent);
                enemyView.Init(enemies[i], GetEnemySprite(enemies[i].ID));
                enemiesView[i] = enemyView;
            }
        }

        private Sprite GetEnemySprite(EnemyIDs id)
        {
            return _enemies[id];
        }

        private void OnDisable()
        {
            if (_world != null)
                _world.BattleInitiated -= OnBattleInitiated;
        }
    }
}