using System.Collections;
using UnityEngine;
using Game.Model;
using Game.View;
using System.Linq;
using System;

namespace Game.Controller
{
    public class BattleController : MonoBehaviour
    {
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] private EnemyViewFactory _enemyViewFactory;
        [SerializeField] private PointerView _pointerView;
        [SerializeField][Range(0, 5)] private float _delay;

        private EnemyView[] _currentEnemies;
        private BattleState _currentBattle;
        private World _world;

        public void Init(World world)
        {
            _world = world;
            _world.BattleInitiated += OnBattleInitiated;
        }

        private void OnBattleInitiated(BattleState battle)
        {
            _currentBattle = battle;
            _currentBattle.PlayerAttackRecieved += OnPlayerAttackRecieved;
            _currentBattle.AllEnemiesAttacked += OnAllEnemiesAttacked;
            _currentBattle.EnemyAttacked += OnEnemyAttacked;
            _currentBattle.Ended += OnBattleEnded;
            _currentBattle.TargetChanged += ChangePointerPosition;
            _playerMovementController.StopMoving();
        }

        private void OnBattleEnded()
        {
            _currentBattle.PlayerAttackRecieved -= OnPlayerAttackRecieved;
            _currentBattle.AllEnemiesAttacked -= OnAllEnemiesAttacked;
            _currentBattle.EnemyAttacked -= OnEnemyAttacked;
            _currentBattle.Ended -= OnBattleEnded;
            _currentBattle.TargetChanged -= ChangePointerPosition;

            foreach (var enemyView in _currentEnemies)
                enemyView.Selected -= OnEnemySelected;

            _enemyViewFactory.DeleteEnemies();
            _playerMovementController.ContinueMoving();
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

        private void OnEnemiesSpawned(EnemyView[] views)
        {
            _currentEnemies = views;

            foreach (var enemyView in _currentEnemies)            
                enemyView.Selected += OnEnemySelected;          
        }

        private void OnEnemySelected(Enemy enemy)
        {
            if (_currentBattle.TryChangeTarget(enemy))
                ChangePointerPosition(enemy);
        }

        private void ChangePointerPosition(Enemy enemy)
        {
            EnemyView enemyView = _currentEnemies.Where(view => view.Self == enemy).FirstOrDefault();
            _pointerView.ChangePosition(enemyView.transform, enemyView.PointerPosition);
        }

        private void OnEnable()
        {
            _enemyViewFactory.EnemiesSpawned += OnEnemiesSpawned;
        }

        private void OnDisable()
        {
            if (_world != null)
                _world.BattleInitiated -= OnBattleInitiated;

            _enemyViewFactory.EnemiesSpawned -= OnEnemiesSpawned;
        }
    }
}