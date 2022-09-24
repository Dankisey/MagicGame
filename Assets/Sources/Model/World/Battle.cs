using UnityEngine;

namespace Game.Model
{
    public class Battle
    {
        private readonly Player _player;
        private readonly Character[] _enemies;
        private int _currentTargetID;

        public Battle(Player player, Character[] enemies)
        {
            _player = player;
            _enemies = enemies;
            _currentTargetID = 0;
            Test();
        }

        public IDamageTaker Target => _enemies[_currentTargetID]; 

        public void ChangeTarget(Changer changer)
        {
            _currentTargetID += (int)changer;

            if (_currentTargetID < 0)
                _currentTargetID = _enemies.Length - 1;
            else if (_currentTargetID >= _enemies.Length)
                _currentTargetID = 0;
        }

        private void Test()
        {
            _enemies[0].DamageTaken += TestLog;
        }

        private void TestLog(float damageTaken)
        {
            Debug.Log($"{damageTaken} damage taken {_enemies[0].Health.Value}/{_enemies[0].Health.MaxValue}");
        }
    }

    public enum Changer
    {
        Down = -1,
        Up = +1
    }
}