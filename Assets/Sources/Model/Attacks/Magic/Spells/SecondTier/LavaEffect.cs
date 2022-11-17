namespace Game.Model
{
    public sealed class LavaEffect : SecondTierEffect
    {
        public LavaEffect() : base(SecondTierElementTypes.Lava, Config.Magic.Effects.Lava.TickCount) { }

        public override int Potency => Config.Magic.Effects.Lava.Potency;

        protected override MagicEffect[] GetCombination(FireEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.Augmented;

            return new MagicEffect[2] { this, effect };
        }

        protected override MagicEffect[] GetCombination(WaterEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[2] { this, effect };
        }

        protected override MagicEffect[] GetCombination(EarthEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.Augmented;

            return new MagicEffect[2] { this, effect };
        }

        protected override MagicEffect[] GetCombination(AirEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[2] { this, effect };
        }

        protected override MagicEffect[] GetCombination(ThunderEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[2] { this, effect };
        }
    }
}