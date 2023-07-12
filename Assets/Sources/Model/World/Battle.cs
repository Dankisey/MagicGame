using System;
using System.Collections.Generic;

namespace Game.Model
{
    public sealed class Battle : IState
    {
        private readonly Player _player;
        private readonly Enemy[] _enemies;
        private readonly List<Enemy> _aliveEnemies;
        private int _targetID = 0;

        public Battle(Player player, Enemy[] enemies)
        {
            _player = player;
            _enemies = enemies;
            _aliveEnemies = new();

            foreach (var enemy in _enemies)          
                _aliveEnemies.Add(enemy);           
                
            PlayerTurn = true;
        }

        public bool PlayerTurn {get; private set;}

        public event Action<Enemy> EnemyAttacked;
        public event Action AllEnemiesAttacked;
        public event Action PlayerAttackRecieved;
        public event Action Ended;

        public IReadOnlyCollection<Enemy> AliveEnemies => _aliveEnemies;
        public Enemy Target => _aliveEnemies[_targetID]; 

        public void Enter()
        {
            PrepareForBattle();
        }

        public void SendPlayerAttack(Attack attack)
        {
            if (PlayerTurn == false)
                return;

            switch (attack.TargetType)
            {
                case (TargetType.Solo):
                    Target.ApplyAttack(attack);
                    break;

                case (TargetType.Multi):
                    foreach (var target in _enemies)
                        target.ApplyAttack(attack);
                    break;
            }

            PlayerTurn = false;
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
            PlayerTurn = true;
        }

        public void ChangeTarget(Changer changer)
        {
            _targetID += (int)changer;

            if (_targetID < 0)
                _targetID = _aliveEnemies.Count - 1;
            else if (_targetID >= _aliveEnemies.Count)
                _targetID = 0;
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

            _player.EnterBattleMod(this);
            _player.Died += OnPlayerDeath;
        }

        private void OnPlayerDeath(Character player)
        {
            foreach (var enemy in _enemies)          
                enemy.Died -= OnEnemieDeath;

            _player.Died -= OnPlayerDeath;

            Ended?.Invoke();
        }

        private void OnEnemieDeath(Character enemy)
        {
            enemy.Died -= OnEnemieDeath;
            _aliveEnemies.Remove(enemy as Enemy);

            if (_aliveEnemies.Count <= 0)
            {
                _player.Died -= OnPlayerDeath;
                Ended?.Invoke();

                return;
            }

            SetNewTarget();
        }

        private void Tick()
        {
            _player.Tick();

            foreach (var enemy in _enemies)         
                enemy.Tick();

            PlayerTurn = true;
        }

        private void SetNewTarget()
        {
            _targetID = 0;
        }
    }

    public enum Changer
    {
        Down = -1,
        Up = +1
    }
}