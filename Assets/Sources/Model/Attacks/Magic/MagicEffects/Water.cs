namespace Game.Model
{
    public sealed class Water : MagicEffect
    {
        public Water() :
        base(new MagicDamage(Config.Magic.Water.Damage, DamageElements.Water),
        new TickDamage(Config.Magic.Water.TickDamage, DamageElements.Water, Config.Magic.Water.TickCount),
        Config.Magic.Water.TargetType, Config.Magic.Water.Cost)
        { }

        public override Attack GetTriplet()
        {
            float damageAmount = Config.Magic.Water.Damage * Config.Magic.AugmentedMultiplier * Config.Magic.Water.Triplet.Multiplier;
            MagicDamage damage = new(damageAmount, DamageElements.Water);
            TickDamage tickDamage = new(Config.Magic.Water.Triplet.TickDamage, DamageElements.Water, Config.Magic.Water.Triplet.TickCount);

            return new Attack(damage, tickDamage, new EmptyDebuff(), Config.Magic.Air.Triplet.TargetType);
        }
    }
}