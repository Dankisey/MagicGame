namespace Game.Model
{
    public abstract class FirstTierSpell : Spell, ITripletReturner
    {
        protected FirstTierSpell(ElementTypes type)
        {
            Type = type;
        }

        public ElementTypes Type { get; private set; }

        public override Spell Combine(ICombineable spell) => GetCombination((dynamic)spell);

        public abstract Spell GetTriplet();

        protected abstract Spell GetCombination(FireSpell spell);

        protected abstract Spell GetCombination(WaterSpell spell);

        protected abstract Spell GetCombination(EarthSpell spell);

        protected abstract Spell GetCombination(AirSpell spell);
    }

    public enum ElementTypes
    {
        Fire,
        Water,
        Earth,
        Air,
    }
}