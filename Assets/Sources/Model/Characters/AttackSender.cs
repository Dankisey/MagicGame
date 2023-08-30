using System;

namespace Game.Model
{
    public abstract class AttackSender
    {
        private DamageBuffsContainer _damageBuffsContainer;

        public AttackSender(DamageBuffsContainer damageBuffsContainer)
        {
            _damageBuffsContainer = damageBuffsContainer;
        }

        public event Action<Attack> AttackSent;

        protected void SendAttack(Attack attack)
        {
            Attack resultAttack = _damageBuffsContainer.GetBuffedAttack(attack);
            AttackSent?.Invoke(resultAttack);
        }
    }
}