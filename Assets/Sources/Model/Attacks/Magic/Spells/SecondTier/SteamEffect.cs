namespace Game.Model
{
    public sealed class SteamEffect : SecondTierEffect
    {
        public SteamEffect() : base(SecondTierElementTypes.Steam, Config.Magic.Effects.Steam.TickCount) { }

        public override int Potency => Config.Magic.Effects.Steam.Potency;

        protected override MagicEffect[] GetCombination(FireEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.Augmented;

            return new MagicEffect[2] { this, effect };
        }

        protected override MagicEffect[] GetCombination(WaterEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.Augmented;

            return new MagicEffect[2] { this, effect };
        }

        protected override MagicEffect[] GetCombination(EarthEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.Augmented;

            return new MagicEffect[1] { new MudEffect() };
        }

        protected override MagicEffect[] GetCombination(AirEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.Augmented;

            return new MagicEffect[1] { new ColdEffect() };
        }

        protected override MagicEffect[] GetCombination(ThunderEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.Augmented;

            return new MagicEffect[2] { this, effect };
        }
    }
}