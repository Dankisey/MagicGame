namespace Game.Model
{
    public class Battle
    {
        private readonly Player _player;
        private Character[] _enemies;
        private int _currentTarget;

        public Battle(Player player)
        {
            _player = player;
        }

        public void Initialize(Character[] enemies)
        {
            _enemies = enemies;
            _currentTarget = 0;
        }

        public void ChangeTarget(Changer changer)
        {
            _currentTarget += (int)changer;

            if (_currentTarget < 0)
                _currentTarget = _enemies.Length - 1;
            else if (_currentTarget >= _enemies.Length)
                _currentTarget = 0;
        }
    }

    public enum Changer
    {
        Down = -1,
        Up = +1
    }
}