namespace Game.Model
{
    public abstract class Element
    {
        protected Element(ElementTypes type)
        {
            Type = type;
        }

        public ElementTypes Type { get; private set; }

        public abstract FirstTierSpell GetSpell();
    }

    public struct SecondTierSpellCharacteristics
    {
        public SecondTierSpellCharacteristics(SecondTierElementTypes type, bool isAugmented)
        {
            IsAugmented = isAugmented;
            Type = type;
        }

        public SecondTierElementTypes Type;
        public bool IsAugmented;
    }

    public struct ThirdTierSpellCharacteristics
    {
        public ThirdTierSpellCharacteristics(ThirdTierElementTypes type, bool isAugmented)
        {
            IsAugmented = isAugmented;
            Type = type;
        }

        public ThirdTierElementTypes Type;
        public bool IsAugmented;
    }
}