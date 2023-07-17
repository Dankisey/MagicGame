namespace Game.Model
{
    public sealed class Fire : MagicEffect
    {
        public Fire() : base(DamageElements.Fire, Config.Magic.Fire.TargetType) { }

        public override Attack GetTriplet()
        {
            float damageAmount = Config.Magic.Fire.Damage * Config.Magic.AugmentedMultiplier * Config.Magic.Fire.Triplet.Multiplier;
            MagicDamage damage = new(damageAmount, new DamageElements[1] { DamageElements.Fire });
            TickDamage tickDamage = new(Config.Magic.Fire.Triplet.TickDamage, new DamageElements[1] { DamageElements.Fire }, Config.Magic.Fire.Triplet.TickCount);

            return new Attack(damage, tickDamage, new Debuff[0], Config.Magic.Fire.Triplet.TargetType);
        }

        protected override void SetDamages()
        {
            Damage = new MagicDamage(Config.Magic.Fire.Damage, new DamageElements[1] { DamageElements.Fire });
            TickDamage = new TickDamage(Config.Magic.Fire.TickDamage, new DamageElements[1] { DamageElements.Fire }, Config.Magic.Fire.TickCount);
        }
    }
}