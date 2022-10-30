namespace Game.Model
{
    public sealed class FireSpell : FirstTierSpell
    {
        public FireSpell() : base(ElementTypes.Fire) { }

        public override Spell GetTriplet()
        {
            throw new System.NotImplementedException();
        }

        protected override Spell GetCombination(FireSpell spell)
        {
            return new AugmentedFireSpell();
        }

        protected override Spell GetCombination(WaterSpell spell)
        {
            return new SteamSpell();
        }

        protected override Spell GetCombination(EarthSpell spell)
        {
            return new LavaSpell();
        }

        protected override Spell GetCombination(AirSpell spell)
        {
            return new GasSpell();
        }
    }
}