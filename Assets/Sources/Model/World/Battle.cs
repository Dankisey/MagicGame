namespace Game.Model
{
    public class Battle
    {
        private Player _player;
        private Character[] enemies;

        public Battle(Player player, Character[] enemies)
        {
            _player = player;
        }

        public Character CurrentTarget { get; private set; }
    }
}