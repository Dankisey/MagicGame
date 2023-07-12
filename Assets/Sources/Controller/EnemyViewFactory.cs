using System.Collections.Generic;
using UnityEngine;
using Game.Model;
using System.Linq;
using System;

namespace Game.Controller
{
    public class EnemyViewFactory : MonoBehaviour
    {
        [SerializeField] private List<EnemyViewData> _enemyViewDatas;
        [SerializeField] private EnemyView _template;
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
            IEnumerable<EnemyViewData> datas = _enemyViewDatas.Where(data => data.ID == id);
            EnemyViewData data = datas.FirstOrDefault();

            return data.Sprite;
        }

        private void OnDisable()
        {
            if (_world != null)
                _world.BattleInitiated -= OnBattleInitiated;
        }
    }

    [Serializable]
    public struct EnemyViewData
    {
        [SerializeField] public Sprite Sprite;
        [SerializeField] public EnemyIDs ID; 
    }
}