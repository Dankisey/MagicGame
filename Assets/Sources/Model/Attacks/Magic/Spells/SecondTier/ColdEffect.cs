namespace Game.Model
{
    public sealed class ColdEffect : SecondTierEffect
    {
        public ColdEffect() : base(SecondTierElementTypes.Cold, Config.Magic.Effects.Cold.TickCount) { }

        public override int Potency => Config.Magic.Effects.Cold.Potency;

        public override bool CheckMatching(Element element)
        {
            if (element is Fire)
                return false;

            return true;
        }

        protected override MagicEffect[] GetCombination(FireEffect effect, out AugmentedStatus status)
        {
            throw new System.InvalidOperationException();
        }

        protected override MagicEffect[] GetCombination(WaterEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.Augmented;

            return new MagicEffect[2] { this, effect };
        }

        protected override MagicEffect[] GetCombination(EarthEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[2] { this, effect };
        }

        protected override MagicEffect[] GetCombination(AirEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.Augmented;

            return new MagicEffect[2] { this, effect };
        }

        protected override MagicEffect[] GetCombination(ThunderEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.Augmented;

            return new MagicEffect[2] { this, effect };
        }
    }
}