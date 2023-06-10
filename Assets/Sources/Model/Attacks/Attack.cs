using System.Collections.Generic;

namespace Game.Model
{
    public struct Attack 
    {
        public Attack(Damage damage, TickDamage tickDamage, Debuff[] debuffs, TargetType targetType) 
        {
            Damage = damage;
            TickDamage = tickDamage;
            Debuffs = debuffs;
            TargetType = targetType;
        }

        //public Attack(Spell spell)
        //{

        //}

        public readonly TickDamage TickDamage;
        public readonly Damage Damage;
        public readonly Debuff[] Debuffs;
        public readonly TargetType TargetType;
    }

    public enum TargetType
    {
        Solo,
        Multi
    }
}