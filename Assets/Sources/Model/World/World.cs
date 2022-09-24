namespace Game.Model
{
    public class World
    {
        private readonly Player _player;
        public Battle CurrentBattle;

        public World(Player player)
        {
            _player = player;
        }

        public void InitiateBattle()
        {
            CurrentBattle = new(_player, new Character[1] { new Bat()});
        }
    }
}