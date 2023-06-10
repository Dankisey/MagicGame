namespace Game.Model
{
    public sealed class Thunder : Effect, IMagicEffect
    {
        public Thunder() : base(DamageElements.Thunder, Config.Magic.Thunder.TargetType) { }

        public Attack GetTripplet()
        {
            float damageAmount = Config.Magic.Thunder.Damage * Config.Magic.AugmentedMultiplier * Config.Magic.Thunder.Triplet.Multiplier;
            MagicDamage damage = new(damageAmount, new DamageElements[1] { DamageElements.Thunder });
            TickDamage tickDamage = new(Config.Magic.Thunder.TickDamage, new DamageElements[1] { DamageElements.Thunder }, Config.Magic.Thunder.Triplet.TickCount);

            return new Attack(damage, tickDamage, new Debuff[0], Config.Magic.Thunder.Triplet.TargetType);
        }

        protected override void SetDamages()
        {
            Damage = new MagicDamage(Config.Magic.Thunder.Damage, new DamageElements[1] { DamageElements.Thunder });
            TickDamage = new TickDamage(Config.Magic.Thunder.TickDamage, new DamageElements[1] { DamageElements.Thunder }, Config.Magic.Thunder.TickCount);
        }
    }
}