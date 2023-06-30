namespace Game.Model
{
    public class Bat : Enemy
    {
        public Bat() : 
            base(nameof(Bat), EnemyIDs.Bat, Config.Characters.Enemies.Bat.DamagableCharacteristics, new BatAttackFactory()) { }
    }
}