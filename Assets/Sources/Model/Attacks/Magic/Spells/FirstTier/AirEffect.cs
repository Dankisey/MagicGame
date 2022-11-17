namespace Game.Model
{
    public sealed class AirEffect : FirstTierEffect
    {
        public AirEffect() : base(ElementTypes.Air, Config.Magic.Effects.Air.TickCount) { }

        public override int Potency => Config.Magic.Effects.Air.Potency;

        protected override MagicEffect[] GetCombination(FireEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[2] { this, effect };
        }

        protected override MagicEffect[] GetCombination(WaterEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[1] { new ColdEffect() };
        }

        protected override MagicEffect[] GetCombination(EarthEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[1] { new DustEffect() };
        }

        protected override MagicEffect[] GetCombination(AirEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.Augmented;

            return new MagicEffect[2] { this, effect};
        }

        protected override MagicEffect[] GetCombination(ThunderEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[2] { this, new ThunderEffect() };
        }
    }
}