﻿namespace Game.Model
{
    public abstract class MagicEffect : Effect
    {
        protected MagicEffect(DamageElements element, TargetType targetType, int manaCost) : base(element, targetType) 
        {
            ManaCost = manaCost;
        }

        public int ManaCost { get; private set; }

        public abstract Attack GetTriplet();
    }
}