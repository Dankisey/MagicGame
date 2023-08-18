using System;

namespace Game.Model
{
    public abstract class Effect
    {
        public Effect(DamageElements element, TargetTypes targetType)
        {
            TargetType = targetType;
            Element = element;
            SetDamages();
            CheckForNulls();
        }

        public TargetTypes TargetType { get; private set; }
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
}