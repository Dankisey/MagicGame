using System;

namespace Game.Model
{
    public abstract class MagicEffect : Effect
    {
        protected MagicEffect(DamageElements element, TargetType targetType) : base(element, targetType) { }

        public abstract Attack GetTriplet();
    }
}