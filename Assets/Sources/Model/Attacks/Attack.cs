using System.Collections.Generic;

namespace Game.Model
{
    public struct Attack 
    {
        public Attack(Damage damage, TickDamage tickDamage, Debuff debuff, TargetTypes targetType)
        {
            Damages = new Damage[1] { damage };
            TickDamages = new TickDamage[1] { tickDamage };
            Debuffs = new Debuff[1] { debuff };
            TargetType = targetType;
        }

        public Attack(Damage[] damages, TickDamage[] tickDamages, Debuff[] debuffs, TargetTypes targetType) 
        {
            Damages = damages;
            TickDamages = tickDamages;
            Debuffs = debuffs;
            TargetType = targetType;
        }

        public Attack MultiplyDamages(List<DamageMultiplier> multipliers)
        {
            foreach (var multiplier in multipliers)           
                MultiplyDamage(multiplier);
           
            return this;
        }

        public Attack MultiplyAll(AllMultiplier multiplier)
        {
            foreach (Damage damage in Damages)
                damage.MultiplyDamage(multiplier.Value);
            
            foreach (TickDamage damage in TickDamages)
                damage.MultiplyDamage(multiplier.Value);

            return this;
        }

        private Attack MultiplyDamage(DamageMultiplier multiplier)
        {
            foreach (Damage damage in Damages)
            {
                if (damage.Element == multiplier.Element)
                    damage.MultiplyDamage(multiplier.Value);
            }

            foreach (TickDamage damage in TickDamages)
            {
                if (damage.Element == multiplier.Element)
                    damage.MultiplyDamage(multiplier.Value);
            }

            return this;
        }

        public readonly TickDamage[] TickDamages;
        public readonly Damage[] Damages;
        public readonly Debuff[] Debuffs;
        public readonly TargetTypes TargetType;
    }

    public enum TargetTypes
    {
        Solo,
        Multi
    }
}