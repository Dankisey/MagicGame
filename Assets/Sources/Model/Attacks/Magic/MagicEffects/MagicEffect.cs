namespace Game.Model
{
    public abstract class MagicEffect : Effect
    {
        public MagicEffect(Damage damage, TickDamage tickDamage, TargetTypes targetType, int manaCost) : base(damage, tickDamage, targetType) 
        {
            ManaCost = manaCost;
        }

        public int ManaCost { get; private set; }

        public abstract Attack GetTriplet();
    }
}