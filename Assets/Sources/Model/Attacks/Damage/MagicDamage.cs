namespace Game.Model
{
    public sealed class MagicDamage : Damage
    {
        public MagicDamage(float amount, DamageElements[] elements) : base(amount, elements) { }
    }
}