namespace Game.Model
{
    public abstract class Damage
    {
        public Damage(float amount, DamageElements[] elements)
        {
            Amount = amount;
            Elements = elements;
        }

        public DamageElements[] Elements { get => GetElements(); private set => Elements = value; }
        public float Amount { get; private set; }

        public DamageElements[] GetElements()
        {
            DamageElements[] elements = new DamageElements[Elements.Length];

            for (int i = 0; i < Elements.Length; i++)
                elements[i] = Elements[i];
            
            return elements;
        }
    }

    public enum DamageElements
    {
        Pure = 0,
        Physical,
        Fire,
        Water,
        Air,
        Earth,
        Thunder
    }
}