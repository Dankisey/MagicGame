using System;
using System.Linq;

namespace Game.Model
{
    public sealed class Battle : IState
    {
        private readonly Player _player;
        private readonly Enemy[] _enemies;
        private int _defeatedEnemies = 0;
        private int _targetID = 0;

        public Battle(Player player, Enemy[] enemies)
        {
            _player = player;
            _enemies = enemies;       
        }

        public event Action Ended;

        public IDamageTaker Target => _enemies[_targetID]; 
        public int EnemiesAmount => _enemies.Length;

        public void Enter()
        {
            PrepareForBattle();
        }

        public void SendPlayerAttack(Attack attack)
        {
            switch (attack.Type)
            {
                case (TargetType.Solo):
                    Target.TakeDamage(attack.Damage);
                    break;

                case (TargetType.Multi):
                    foreach (var target in _enemies)
                        target.TakeDamage(attack.Damage);
                    break;
            }
        }

        public void ChangeTarget(Changer changer)
        {
            _targetID += (int)changer;

            if (_targetID < 0)
                _targetID = _enemies.Length - 1;
            else if (_targetID >= _enemies.Length)
                _targetID = 0;
        }

        public Enemy[] GetEnemies()
        {
            return _enemies;
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
            _defeatedEnemies++;

            if (_defeatedEnemies >= EnemiesAmount)
            {
                _player.Died -= OnPlayerDeath;
                Ended?.Invoke();

                return;
            }

            SetNewTarget();
        }

        private void SetNewTarget()
        {
            Character newTarget = _enemies.FirstOrDefault(character => character.IsAlive);
            _targetID = Array.IndexOf(_enemies, newTarget);
        }
    }

    public enum Changer
    {
        Down = -1,
        Up = +1
    }
}