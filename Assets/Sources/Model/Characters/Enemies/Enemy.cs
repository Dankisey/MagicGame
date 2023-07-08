namespace Game.Model
{
    public abstract class Enemy : Character
    {
        private readonly EnemyAttackFactory _attackFactory;

        public Enemy(string name, DamagableCharacteristics characteristics, EnemyAttackFactory attackFactory) 
            : base(characteristics) 
        {
            _attackFactory = attackFactory;
            Name = name;
            Init();
        }

        public virtual Attack GetAttack() => _attackFactory.GetAttack();

        public EnemyIDs ID { get; protected set; }
        public string Name { get; private set; }

        protected abstract void Init();
    }

    public enum EnemyIDs
    {
        Bat = 1,
    }
}