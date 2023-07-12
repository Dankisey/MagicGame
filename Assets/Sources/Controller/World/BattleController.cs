using System.Collections;
using System;
using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public class BattleController : MonoBehaviour
    {
        [SerializeField][Range(0, 5)] private float _delay;

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
            _currentBattle.PlayerAttackRecieved += OnPlayerAttackRecieved;
            _currentBattle.AllEnemiesAttacked += OnAllEnemiesAttacked;
            _currentBattle.EnemyAttacked += OnEnemyAttacked;
            _currentBattle.Ended += OnBattleEnded;
        }

        private void OnBattleEnded()
        {
            _currentBattle.PlayerAttackRecieved -= OnPlayerAttackRecieved;
            _currentBattle.AllEnemiesAttacked -= OnAllEnemiesAttacked;
            _currentBattle.EnemyAttacked -= OnEnemyAttacked;
            _currentBattle.Ended -= OnBattleEnded;
        }

        private void OnEnemyAttacked(Enemy enemy)
        {
            
        }

        private void OnAllEnemiesAttacked()
        {

        }

        private void OnPlayerAttackRecieved()
        {
            StartCoroutine(nameof(PerformEnemiesAttack));
        }

        private IEnumerator PerformEnemiesAttack()
        {
            foreach  (Enemy enemy in _currentBattle.AliveEnemies)
            {
                yield return new WaitForSeconds(_delay);

                _currentBattle.PerformEnemyAttack(enemy);
            }

            yield return new WaitForSeconds(_delay);

            _currentBattle.EndEnemyTurn();
        }

        private void OnEnable()
        {
            if (_world != null)
                _world.BattleInitiated += OnBattleInitiated;
        }

        private void OnDisable()
        {
            if (_world != null)
                _world.BattleInitiated -= OnBattleInitiated;
        }
    }
}