namespace Game.Model
{
    public sealed class WaterSpell : FirstTierSpell
    {
        public WaterSpell() : base(ElementTypes.Water) { }

        public override Spell GetTriplet()
        {
            throw new System.NotImplementedException();
        }

        protected override Spell GetCombination(FireSpell spell)
        {
            return new SteamSpell();
        }

        protected override Spell GetCombination(WaterSpell spell)
        {
            return new AugmentedWaterSpell();
        }

        protected override Spell GetCombination(EarthSpell spell)
        {
            return new MudSpell();
        }

        protected override Spell GetCombination(AirSpell spell)
        {
            return new IceSpell();
        }
    }
}