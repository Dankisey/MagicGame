using System;

namespace Game.Model
{
    public abstract class Effect
    {
        public Effect(DamageElements element, TargetType targetType)
        {
            TargetType = targetType;
            Element = element;
            SetDamages();
            CheckForNulls();
        }

        public TargetType TargetType { get; private set; }
        public DamageElements Element { get; private set; }
        public TickDamage TickDamage { get; protected set; }
        public Damage Damage { get; protected set; }

        protected abstract void SetDamages();

        private void CheckForNulls()
        {
            if (Damage == null)
                throw new ArgumentNullException(nameof(Damage));

            if (TickDamage == null)
                throw new ArgumentNullException(nameof(TickDamage));
        }
    }

    public interface IMagicEffect
    {
        public Attack GetTripplet();
    }
}