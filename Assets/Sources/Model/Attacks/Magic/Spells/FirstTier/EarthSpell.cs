namespace Game.Model
{
    public sealed class EarthSpell : FirstTierSpell
    {
        public EarthSpell() : base(ElementTypes.Earth) { }

        public override Spell GetTriplet()
        {
            throw new System.NotImplementedException();
        }

        protected override Spell GetCombination(FireSpell spell)
        {
            return new LavaSpell();
        }

        protected override Spell GetCombination(WaterSpell spell)
        {
            return new MudSpell();
        }

        protected override Spell GetCombination(EarthSpell spell)
        {
            return new AugmentedEarthSpell();
        }

        protected override Spell GetCombination(AirSpell spell)
        {
            return new DustSpell();
        }
    }
}