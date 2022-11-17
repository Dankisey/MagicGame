using System;

namespace Game.Model
{
    public sealed class WaterEffect : FirstTierEffect
    {
        public WaterEffect() : base(ElementTypes.Water, Config.Magic.Effects.Water.TickCount) => Potency = Config.Magic.Effects.Water.Potency;

        public override int Potency { get; }

        public override bool CheckMatching(Element element)
        {
            if (element is Thunder)
                return false;

            return true;
        }

        protected override MagicEffect[] GetCombination(FireEffect efffect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[1] { new SteamEffect() }; 
        }

        protected override MagicEffect[] GetCombination(WaterEffect efffect, out AugmentedStatus status)
        {
            status = AugmentedStatus.Augmented;

            return new MagicEffect[2] { this, efffect};
        }

        protected override MagicEffect[] GetCombination(EarthEffect efffect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[1] { new MudEffect() };
        }

        protected override MagicEffect[] GetCombination(AirEffect efffect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[1] { new ColdEffect() };
        }

        protected override MagicEffect[] GetCombination(ThunderEffect efffect, out AugmentedStatus status)
        {
            throw new InvalidOperationException();
        }
    }
}