namespace Game.Model
{
    public class Bat : Enemy
    {
        public Bat() : base(Player.Instance, nameof(Bat), Config.Characters.Enemies.Bat.DamagableCharacteristics) { }
    }

    public abstract class Enemy : Character
    {
        public readonly string Name;

        private readonly Player _target;

        public Enemy(Player target, string name, DamagableCharacteristics characteristics) : base(characteristics) 
        {
            Name = name;
            _target = target;
        }
    }
}