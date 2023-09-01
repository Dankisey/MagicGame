namespace Game.Model
{
    public abstract class Damage : IClonable
    {
        public Damage(float amount, DamageElements element)
        {
            Amount = amount;
            Element = element;
        }

        public DamageElements Element { get; private set; }
        public float Amount { get; private set; }

        public abstract object GetCopy();

        public void MultiplyDamage(float multiplier)
        {
            Amount += Amount * multiplier;

            if (Amount < 0)
                Amount = 0;
        }
    }

    public enum DamageElements
    {      
        None,
        Pure,
        Physical,
        Fire = 10,
        Water,
        Air,
        Earth,
        Thunder
    }
}