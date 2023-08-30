namespace Game.Model
{
    public sealed class None : MagicEffect
    {
        public None() :
            base(new MagicDamage(Config.Magic.None.Damage, DamageElements.None),
            new TickDamage(Config.Magic.None.TickDamage, DamageElements.None, Config.Magic.None.TickCount),
            Config.Magic.None.TargetType, Config.Magic.None.Cost) { }

        public override Attack GetTriplet()
        {
            float damageAmount = 0;
            MagicDamage damage = new(damageAmount, DamageElements.None);
            TickDamage tickDamage = new(Config.Magic.None.Triplet.TickDamage, DamageElements.None, Config.Magic.None.Triplet.TickCount);

            return new Attack(damage, tickDamage, new EmptyDebuff(), Config.Magic.Air.Triplet.TargetType);
        }
    }
}