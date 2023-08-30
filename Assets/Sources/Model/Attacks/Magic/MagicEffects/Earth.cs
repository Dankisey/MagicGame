namespace Game.Model
{
    public sealed class Earth : MagicEffect
    {
        public Earth() :
            base(new MagicDamage(Config.Magic.Earth.Damage, DamageElements.Earth),
            new TickDamage(Config.Magic.Earth.TickDamage, DamageElements.Earth, Config.Magic.Earth.TickCount),
            Config.Magic.Earth.TargetType, Config.Magic.Earth.Cost) { }

        public override Attack GetTriplet()
        {
            float damageAmount = Config.Magic.Earth.Damage * Config.Magic.AugmentedMultiplier * Config.Magic.Earth.Triplet.Multiplier;
            PhysicalDamage damage = new(damageAmount, DamageElements.Earth);
            TickDamage tickDamage = new(Config.Magic.Earth.Triplet.TickDamage, DamageElements.Earth, Config.Magic.Earth.Triplet.TickCount);

            return new Attack(damage, tickDamage, new EmptyDebuff(), Config.Magic.Air.Triplet.TargetType);
        }
    }
}