namespace Game.Model
{
    public sealed class AirSpell : FirstTierSpell
    {
        public AirSpell() : base(ElementTypes.Air) { }

        public override Spell GetTriplet()
        {
            throw new System.NotImplementedException();
        }

        protected override Spell GetCombination(FireSpell spell)
        {
            return new GasSpell();
        }

        protected override Spell GetCombination(WaterSpell spell)
        {
            return new IceSpell();
        }

        protected override Spell GetCombination(EarthSpell spell)
        {
            return new DustSpell();
        }

        protected override Spell GetCombination(AirSpell spell)
        {
            return new AugmentedAirSpell();
        }
    }
}