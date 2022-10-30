namespace Game.Model
{
    public sealed class SteamSpell : SecondTierSpell
    {
        public SteamSpell() : base(SecondTierElementTypes.Steam, false) { }

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