namespace Game.Model
{
    public sealed class None : MagicEffect
    {
        public None() : base(DamageElements.None, Config.Magic.None.TargetType) { }

        public override Attack GetTriplet()
        {
            float damageAmount = 0;
            MagicDamage damage = new(damageAmount, new DamageElements[1] { DamageElements.None });
            TickDamage tickDamage = new(Config.Magic.None.TickDamage, new DamageElements[1] { DamageElements.None }, Config.Magic.None.Triplet.TickCount);

            return new Attack(damage, tickDamage, new Debuff[0], Config.Magic.None.Triplet.TargetType);
        }

        protected override void SetDamages()
        {
            Damage = new MagicDamage(Config.Magic.None.Damage, new DamageElements[1] { DamageElements.None });
            TickDamage = new TickDamage(Config.Magic.None.TickDamage, new DamageElements[1] { DamageElements.None }, Config.Magic.None.TickCount);
        }
    }
}