namespace Game.Model
{
    public sealed class PhysicalDamage : Damage
    {
        public PhysicalDamage(float amount, DamageElements[] elements) : base(amount, elements) { }    
    }
}