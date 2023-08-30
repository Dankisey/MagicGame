using System;
using System.Collections.Generic;

namespace Game.Model
{
    public sealed class Spell
    {
        private readonly MagicEffect[] _effects;

        public Spell(MagicEffect[] effects) 
        {
            if (effects.Length > Config.Magic.MaxEffectsInSpell)
                throw new ArgumentOutOfRangeException(nameof(effects.Length));

            _effects = effects;
        }  

        public Spell(MagicEffect effect) 
        {
            _effects = new MagicEffect[] {effect};
        }

        public Attack ToAttack()
        {
            TickDamage[] tickDamages = CalculateTickDamages();
            Damage[] damages = CalculateDamages();
            Debuff[] debuffs = CalculateDebuffs();
            TargetTypes targetType = CalculateTargetType();

            return new Attack(damages, tickDamages, debuffs, targetType);
        }

        private Damage[] CalculateDamages()
        {
            List<Damage> damages = new();

            foreach (var effect in _effects)
            {
                if (effect.Element == DamageElements.None)
                    break;

                damages.Add(effect.Damage);
            }
            
            return damages.ToArray();
        }

        private TickDamage[] CalculateTickDamages()
        {
            List<TickDamage> tickDamages = new();
            int totalTickAmount = 0;
            bool isPhysical = false;

            foreach (var effect in _effects)
            {
                if (effect.Damage is PhysicalDamage)
                {
                    isPhysical = true;
                    break;
                }

                if (effect.TickDamage.TickAmount > totalTickAmount)
                    totalTickAmount = effect.TickDamage.TickAmount;
            }

            if (isPhysical)
                return new TickDamage[0];

            foreach (var effect in _effects)
            {
                DamageElements element = effect.Element;

                if (element == DamageElements.None)
                    break;
                
                tickDamages.Add(new TickDamage(effect.TickDamage.Amount, element, totalTickAmount));
            }

            return tickDamages.ToArray();
        }

        private Debuff[] CalculateDebuffs()
        {
            return new Debuff[0];
        }

        private TargetTypes CalculateTargetType()
        {
            foreach (var effect in _effects)
            {
                if (effect.TargetType == TargetTypes.Multi)
                    return TargetTypes.Multi; 
            }

            return TargetTypes.Solo;
        }
    }
}