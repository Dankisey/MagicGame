namespace Game.Model
{
    public sealed class Fire : MagicEffect
    {
        public Fire() :
            base(new MagicDamage(Config.Magic.Fire.Damage, DamageElements.Fire),
            new TickDamage(Config.Magic.Fire.TickDamage, DamageElements.Fire, Config.Magic.Fire.TickCount),
            Config.Magic.Fire.TargetType, Config.Magic.Fire.Cost) { }

        public override Attack GetTriplet()
        {
            float damageAmount = Config.Magic.Fire.Damage * Config.Magic.AugmentedMultiplier * Config.Magic.Fire.Triplet.Multiplier;
            MagicDamage damage = new(damageAmount, DamageElements.Fire);
            TickDamage tickDamage = new(Config.Magic.Fire.Triplet.TickDamage, DamageElements.Fire, Config.Magic.Fire.Triplet.TickCount);

            return new Attack(damage, tickDamage, new EmptyDebuff(), Config.Magic.Air.Triplet.TargetType);
        }
    }
}