using System;
using System.Collections.Generic;

namespace Game.Model
{
    public sealed class Spell
    {
        private readonly List<Effect> _effects;

        public Spell(List<Effect> effects) 
        {
            if (effects.Count > Config.Magic.MaxEffectsInSpell)
                throw new ArgumentOutOfRangeException(nameof(effects.Count));

            _effects = effects;
        }  

        public Spell(Effect effect) 
        {
            _effects = new List<Effect> {effect};
        }

        public Attack ToAttack()
        {
            TickDamage tickDamage = CalculateTickDamage();
            Damage damage = CalculateDamage();
            Debuff[] debuffs = CalculateDebuffs();
            TargetType targetType = CalculateTargetType();

            return new Attack(damage, tickDamage, debuffs, targetType);
        }

        private Damage CalculateDamage()
        {
            bool isPhysical = false;
            float totalDamageAmount = 0;
            Damage damage;
            List<DamageElements> elements = new();

            foreach (var effect in _effects)
            {
                totalDamageAmount += effect.Damage.Amount;
                elements.Add(effect.Element);

                if (effect.Element == DamageElements.Earth)
                    isPhysical = true;
            }

            if (isPhysical)
                damage = new PhysicalDamage(totalDamageAmount, new DamageElements[1] {DamageElements.Physical});
            else
                damage = new MagicDamage(totalDamageAmount, elements.ToArray());

            return damage;
        }

        private TickDamage CalculateTickDamage()
        {
            bool isPhysical = false;
            float totalDamageAmount = 0;
            int totalTickAmount = 0;
            TickDamage damage;
            List<DamageElements> elements = new();

            foreach (var effect in _effects)
            {
                totalDamageAmount += effect.TickDamage.Amount;
                elements.Add(effect.Element);

                if (effect.Element == DamageElements.Earth)
                {
                    isPhysical = true;
                    break;
                }

                if (effect.TickDamage.TickCount > totalTickAmount)
                    totalTickAmount = effect.TickDamage.TickCount;
            }

            if (isPhysical)
                damage = new TickDamage(Config.Magic.PhysicalTickDamage, new DamageElements[1] { DamageElements.Physical }, Config.Magic.PhysicalTickCount);
            else
                damage = new TickDamage(totalDamageAmount, elements.ToArray(), totalTickAmount);

            return damage;
        }

        private Debuff[] CalculateDebuffs()
        {
            return new Debuff[0];
        }

        private TargetType CalculateTargetType()
        {
            TargetType targetType = TargetType.Solo;

            foreach (var effect in _effects)
            {
                if (effect.TargetType == TargetType.Multi)
                    targetType = TargetType.Multi; 
            }

            return targetType;
        }
    }
}