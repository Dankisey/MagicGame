namespace Game.Model
{
    public abstract class Enemy : Character
    {
        private EnemyAttackFactory _attackFactory;

        public Enemy(string name, EnemyIDs id, DamagableCharacteristics characteristics, EnemyAttackFactory attackFactory) 
            : base(characteristics) 
        {
            _attackFactory = attackFactory;
            Name = name;
            ID = id;
        }

        public virtual Attack GetAttack() => _attackFactory.GetAttack();

        public EnemyIDs ID { get; private set; }
        public string Name { get; private set; }
    }

    public enum EnemyIDs
    {
        Bat = 1,
    }
}