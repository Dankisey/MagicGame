namespace Game.Model
{
    public sealed class MagicDamage : Damage
    {
        public MagicDamage(float amount, DamageElements element) : base(amount, element) { }

        public override object GetCopy() => new MagicDamage(Amount, Element);
    }
}