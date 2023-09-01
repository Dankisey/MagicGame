namespace Game.Model
{
    public sealed class PureDamage : Damage
    {
        public PureDamage(float amount) : base(amount, DamageElements.Pure) { }

        public override object GetCopy() => new PureDamage(Amount);
    }
}