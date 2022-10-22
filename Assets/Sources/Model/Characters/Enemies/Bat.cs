namespace Game.Model
{
    public class Bat : Enemy
    {
        public Bat() : base(Player.Instance, nameof(Bat), EnemyIDs.Bat, Config.Characters.Enemies.Bat.DamagableCharacteristics) { }
    }
}