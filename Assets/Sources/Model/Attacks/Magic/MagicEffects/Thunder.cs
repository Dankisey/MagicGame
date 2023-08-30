namespace Game.Model
{
    public sealed class Thunder : MagicEffect
    {
        public Thunder() :
            base(new MagicDamage(Config.Magic.Thunder.Damage, DamageElements.Thunder),
            new TickDamage(Config.Magic.Thunder.TickDamage, DamageElements.Thunder, Config.Magic.Thunder.TickCount),
            Config.Magic.Thunder.TargetType, Config.Magic.Thunder.Cost) { }

        public override Attack GetTriplet()
        {
            float damageAmount = Config.Magic.Thunder.Damage * Config.Magic.AugmentedMultiplier * Config.Magic.Thunder.Triplet.Multiplier;
            MagicDamage damage = new(damageAmount, DamageElements.Thunder);
            TickDamage tickDamage = new(Config.Magic.Thunder.Triplet.TickDamage, DamageElements.Thunder, Config.Magic.Thunder.Triplet.TickCount);

            return new Attack(damage, tickDamage, new EmptyDebuff(), Config.Magic.Air.Triplet.TargetType);
        }
    }
}