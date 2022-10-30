namespace Game.Model
{
    public sealed class IceSpell : SecondTierSpell
    {
        public IceSpell() : base(SecondTierElementTypes.Ice, false) { }

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