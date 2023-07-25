namespace Game.Model
{
    public sealed class Water : MagicEffect
    {
        public Water() : base(DamageElements.Water, Config.Magic.Water.TargetType, Config.Magic.Water.Cost) { }

        public override Attack GetTriplet()
        {
            float damageAmount = Config.Magic.Water.Damage * Config.Magic.AugmentedMultiplier * Config.Magic.Water.Triplet.Multiplier;
            MagicDamage damage = new(damageAmount, new DamageElements[1] { DamageElements.Water });
            TickDamage tickDamage = new(Config.Magic.Water.Triplet.TickDamage, new DamageElements[1] { DamageElements.Water }, Config.Magic.Water.Triplet.TickCount);

            return new Attack(damage, tickDamage, new Debuff[0], Config.Magic.Water.Triplet.TargetType);
        }

        protected override void SetDamages()
        {
            Damage = new MagicDamage(Config.Magic.Water.Damage, new DamageElements[1] { DamageElements.Water });
            TickDamage = new TickDamage(Config.Magic.Water.TickDamage, new DamageElements[1] { DamageElements.Water }, Config.Magic.Water.TickCount);
        }
    }
}