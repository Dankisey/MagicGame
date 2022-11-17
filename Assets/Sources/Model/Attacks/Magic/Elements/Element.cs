namespace Game.Model
{
    public abstract class Element
    {
        protected Element(ElementTypes type)
        {
            Type = type;
        }

        public ElementTypes Type { get; private set; }

        public abstract FirstTierEffect GetEffect();
    }

    public enum ElementTypes
    {
        Fire,
        Water,
        Earth,
        Air,
        Thunder
    }
}