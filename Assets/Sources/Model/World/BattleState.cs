using System;
using System.Collections.Generic;

namespace Game.Model
{
    public sealed class BattleState : IState
    {
        private readonly Player _player;
        private readonly Enemy[] _enemies;
        private readonly List<Enemy> _aliveEnemies;

        public BattleState(Player player, Enemy[] enemies)
        {
            _player = player;
            _enemies = enemies;
            _aliveEnemies = new();

            foreach (var enemy in _enemies)          
                _aliveEnemies.Add(enemy);           
                
            PlayerTurn = true;
        }

        public bool PlayerTurn {get; private set;}

        public event Action<bool> PlayerTurnChanged;
        public event Action<Enemy> TargetChanged;
        public event Action<Enemy> EnemyAttacked;
        public event Action AllEnemiesAttacked;
        public event Action PlayerAttackRecieved;
        public event Action Entered;
        public event Action Ended;

        public IReadOnlyCollection<Enemy> AliveEnemies => _aliveEnemies;
        public Enemy Target { get; private set;}

        public void Enter()
        {
            PrepareForBattle();
            Entered?.Invoke();
            SetNewTarget();
        }

        public void Exit()
        {
            foreach (var enemy in _aliveEnemies)
                enemy.Died -= OnEnemieDeath;

            _player.Died -= OnPlayerDeath;
            Ended?.Invoke();
        }

        public void SendPlayerAttack(Attack attack)
        {
            switch (attack.TargetType)
            {
                case (TargetTypes.Solo):
                    Target.ApplyAttack(attack);
                    break;

                case (TargetTypes.Multi):
                    foreach (var target in _enemies)
                        target.ApplyAttack(attack);
                    break;
            }

            ChangePlayerTurn(false);
            PlayerAttackRecieved?.Invoke();
        }

        public void PerformEnemyAttack(Enemy enemy)
        {
            EnemyAttacked?.Invoke(enemy);
            Attack attack = enemy.GetAttack();
            _player.ApplyAttack(attack);         
        }

        public void EndEnemyTurn()
        {
            AllEnemiesAttacked?.Invoke();
            Tick();
            ChangePlayerTurn(true);
        }

        public bool TryChangeTarget(Enemy enemy)
        {
            if (enemy.IsAlive)
                Target = enemy;

            return enemy.IsAlive;
        }

        public Enemy[] GetEnemies()
        {
            Enemy[] enemies = new Enemy[_enemies.Length];

            for (int i = 0; i < enemies.Length; i++)
                enemies[i] = _enemies[i];

            return enemies;
        }

        private void PrepareForBattle()
        {
            foreach (var enemy in _enemies)
                enemy.Died += OnEnemieDeath;

            _player.Died += OnPlayerDeath;
        }

        private void OnPlayerDeath(Character player)
        {
            Exit();
        }

        private void OnEnemieDeath(Character enemy)
        {
            enemy.Died -= OnEnemieDeath;
            _aliveEnemies.Remove(enemy as Enemy);
            _player.Level.AddExpirience(enemy.Level.GetRewardExperience());

            if (_aliveEnemies.Count <= 0)
            {
                Exit();
                return;
            }
        }

        private void Tick()
        {
            _player.Tick();

            foreach (var enemy in _enemies)         
                enemy.Tick();

           PlayerTurn = true;
           SetNewTarget();
        }

        private void ChangePlayerTurn(bool value)
        {
            PlayerTurn = value;
            PlayerTurnChanged?.Invoke(PlayerTurn);
        }

        private void SetNewTarget()
        {
            if (_aliveEnemies.Contains(Target) || _aliveEnemies.Count == 0)            
                return;

            Target = _aliveEnemies[0];
            TargetChanged?.Invoke(Target);
        }
    }
}