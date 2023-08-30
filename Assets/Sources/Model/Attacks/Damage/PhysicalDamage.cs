namespace Game.Model
{
    public sealed class PhysicalDamage : Damage
    {
        public PhysicalDamage(float amount, DamageElements element) : base(amount, element) { }    
    }
}