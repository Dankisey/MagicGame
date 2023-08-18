namespace Game.Model
{
    public struct Attack 
    {
        public Attack(Damage damage, TickDamage tickDamage, Debuff[] debuffs, TargetTypes targetType) 
        {
            Damage = damage;
            TickDamage = tickDamage;
            Debuffs = debuffs;
            TargetType = targetType;
        }

        public readonly TickDamage TickDamage;
        public readonly Debuff[] Debuffs;
        public readonly Damage Damage;
        public readonly TargetTypes TargetType;
    }

    public enum TargetTypes
    {
        Solo,
        Multi
    }
}