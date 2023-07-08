namespace Game.Model
{
    public class Bat : Enemy
    {
        public Bat() : 
            base(nameof(Bat), Config.Characters.Enemies.Bat.DamagableCharacteristics, new BatAttackFactory()) { }

        protected override void Init()
        {
            ID = EnemyIDs.Bat;
        }
    }
}