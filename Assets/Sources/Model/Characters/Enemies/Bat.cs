namespace Game.Model
{
    public class Bat : Enemy
    {
        public Bat() : 
            base(nameof(Bat), Config.Characters.Enemies.Bat.DamagableCharacteristics, new BatAttackFactory()) { }

        public override Enemy GetNewInstance() => new Bat();

        protected override void Init()
        {
            ID = EnemyIDs.Bat;
        }
    }
}