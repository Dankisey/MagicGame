using System;

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

        public EnemyIDs ID { get; protected set; }
        public string Name { get; private set; }

        public event Action Attacked;

        public virtual Attack GetAttack()
        {
            Attack attack = _attackFactory.GetAttack();
            Attacked?.Invoke();

            return attack;
        }

        public abstract Enemy GetNewInstance();

        protected abstract void Init();
    }

    public enum EnemyIDs
    {
        None = 0,
        Bat
    }
}