namespace Game.Model
{
    public sealed class WaterTriplet : Triplet
    {
        public override int Potency => throw new System.NotImplementedException();

        protected override MagicEffect[] GetCombination(FireEffect effect, out AugmentedStatus status)
        {
            throw new System.NotImplementedException();
        }

        protected override MagicEffect[] GetCombination(WaterEffect effect, out AugmentedStatus status)
        {
            throw new System.NotImplementedException();
        }

        protected override MagicEffect[] GetCombination(EarthEffect effect, out AugmentedStatus status)
        {
            throw new System.NotImplementedException();
        }

        protected override MagicEffect[] GetCombination(AirEffect effect, out AugmentedStatus status)
        {
            throw new System.NotImplementedException();
        }

        protected override MagicEffect[] GetCombination(ThunderEffect effect, out AugmentedStatus status)
        {
            throw new System.NotImplementedException();
        }
    }
}