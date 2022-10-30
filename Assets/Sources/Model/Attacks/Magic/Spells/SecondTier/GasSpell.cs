namespace Game.Model
{
    public sealed class GasSpell : SecondTierSpell
    {
        public GasSpell() : base(SecondTierElementTypes.Gas, false) { }

        protected override Spell GetCombination(FireSpell spell)
        {
            throw new System.NotImplementedException();
        }

        protected override Spell GetCombination(WaterSpell spell)
        {
            throw new System.NotImplementedException();
        }

        protected override Spell GetCombination(EarthSpell spell)
        {
            throw new System.NotImplementedException();
        }

        protected override Spell GetCombination(AirSpell spell)
        {
            throw new System.NotImplementedException();
        }
    }
}