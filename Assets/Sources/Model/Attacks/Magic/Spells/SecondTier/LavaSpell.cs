namespace Game.Model
{
    public sealed class LavaSpell : SecondTierSpell
    {
        public LavaSpell() : base(SecondTierElementTypes.Lava, false) { }

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