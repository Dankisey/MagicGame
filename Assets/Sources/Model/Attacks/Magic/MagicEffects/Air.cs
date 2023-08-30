namespace Game.Model
{
    public sealed class Air : MagicEffect
    {
        public Air() : 
            base(new MagicDamage(Config.Magic.Air.Damage, DamageElements.Air),
            new TickDamage(Config.Magic.Air.TickDamage, DamageElements.Air, Config.Magic.Air.TickCount),
            Config.Magic.Air.TargetType, Config.Magic.Air.Cost) { }

        public override Attack GetTriplet()
        {
            float damageAmount = Config.Magic.Air.Damage * Config.Magic.AugmentedMultiplier * Config.Magic.Air.Triplet.Multiplier;
            MagicDamage damage = new(damageAmount, DamageElements.Air);
            TickDamage tickDamage = new(Config.Magic.Air.Triplet.TickDamage, DamageElements.Air, Config.Magic.Air.Triplet.TickCount);

            return new Attack(damage, tickDamage, new EmptyDebuff(), Config.Magic.Air.Triplet.TargetType);
        }
    }
}