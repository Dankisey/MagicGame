namespace Game.Model
{
    public abstract class Enemy : Character
    {
        private readonly Player _target;

        public Enemy(Player target, string name, EnemyIDs id, DamagableCharacteristics characteristics, AttackSender attackSender, AttackPerformer attackPerformer) 
            : base(characteristics, attackSender, attackPerformer) 
        {
            Name = name;
            ID = id;
            _target = target;
        }

        public abstract Attack GetAttack();

        public EnemyIDs ID { get; private set; }
        public string Name { get; private set; }
    }

    public enum EnemyIDs
    {
        Bat = 1,
    }
}