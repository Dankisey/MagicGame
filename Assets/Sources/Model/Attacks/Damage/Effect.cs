namespace Game.Model
{
    public abstract class Effect
    {
        public Effect(Damage damage, TickDamage tickDamage, TargetTypes targetType)
        {
            Damage = damage;
            TickDamage = tickDamage;
            TargetType = targetType;
        }

        public TargetTypes TargetType { get; private set; }
        public TickDamage TickDamage { get; private set; }
        public Damage Damage { get; private set; }
        public DamageElements Element => Damage.Element;
    }
}