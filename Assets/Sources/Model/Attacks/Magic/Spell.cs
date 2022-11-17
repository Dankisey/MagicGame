using System;
using System.Collections.Generic;

namespace Game.Model
{
    public sealed class Spell
    {
        private List<MagicEffect> _effects;

        public Spell()
        {
            _effects = new List<MagicEffect>();
            AugmentedCount = 0;
        }

        public int AugmentedCount { get; private set; }

        public Damage GetDamage()
        {     
            float damageAmount = GetResultPotency();
            MagicDamage damage = new(damageAmount);

            return damage;
        }

        public Spell AddEffect(MagicEffect effect)
        {
            _effects.Add(effect);

            return this;
        }

        public void Augment(int augmentCount)
        {
            if (augmentCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(augmentCount));

            AugmentedCount += augmentCount;
        }

        private float GetResultPotency()
        {          
            float potency = GetPotency();
            float addPotency = potency * AugmentedCount * Config.Magic.AugmentedMultiplier;

            return potency + addPotency;
        }

        private float GetPotency()
        {
            float potency = 0;

            foreach (var effect in _effects)
                potency += effect.Potency;
            
            return potency;
        }
    }

    public enum SecondTierElementTypes
    {
        Steam,             //water + fire
        Lava,              //earth + fire

        Mud,               //earth + water
        Cold,              //air + water

        Dust               //air + earth
    }
}