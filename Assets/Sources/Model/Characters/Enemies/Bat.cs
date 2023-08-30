namespace Game.Model
{
    public class Bat : Enemy
    {
        public Bat(Level level) : 
            base(nameof(Bat), Config.Characters.Enemies.Bat.DamagableCharacteristics, level, new BatAttackFactory()) { }
    }
}