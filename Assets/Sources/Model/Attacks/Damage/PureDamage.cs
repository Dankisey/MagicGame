namespace Game.Model
{
    public sealed class PureDamage : Damage
    {
        public PureDamage(float amount) : base(amount, new DamageElements[1] { DamageElements.Pure }) { }
    }
}