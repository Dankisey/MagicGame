namespace Game.Model
{
    public sealed class Earth : Effect, IMagicEffect
    {
        public Earth() : base(DamageElements.Earth, Config.Magic.Earth.TargetType) { }

        public Attack GetTripplet()
        {
            float damageAmount = Config.Magic.Earth.Damage * Config.Magic.AugmentedMultiplier * Config.Magic.Earth.Triplet.Multiplier;
            PhysicalDamage damage = new(damageAmount, new DamageElements[1] { DamageElements.Earth });
            TickDamage tickDamage = new(Config.Magic.Earth.TickDamage, new DamageElements[1] { DamageElements.Earth }, Config.Magic.Earth.Triplet.TickCount);

            return new Attack(damage, tickDamage, new Debuff[0], Config.Magic.Earth.Triplet.TargetType);
        }

        protected override void SetDamages()
        {
            Damage = new PhysicalDamage(Config.Magic.Earth.Damage, new DamageElements[1] { DamageElements.Earth });
            TickDamage = new TickDamage(Config.Magic.Earth.TickDamage, new DamageElements[1] { DamageElements.Earth }, Config.Magic.Earth.TickCount);
        }
    }
}