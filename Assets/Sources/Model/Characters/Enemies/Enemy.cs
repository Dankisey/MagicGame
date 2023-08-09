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
        }

        public string Name { get; private set; }

        public event Action Attacked;

        public virtual Attack GetAttack()
        {
            Attack attack = _attackFactory.GetAttack();
            Attacked?.Invoke();

            return attack;
        }
    }
}