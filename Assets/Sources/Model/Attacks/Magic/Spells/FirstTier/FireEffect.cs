using System;

namespace Game.Model
{
    public sealed class FireEffect : FirstTierEffect
    {
        public FireEffect() : base(ElementTypes.Fire, Config.Magic.Effects.Fire.TickCount) { }

        public override int Potency => Config.Magic.Effects.Fire.Potency;

        public override bool CheckMatching(Element element)
        {
            if (element is Thunder)
                return false;

            return true;
        }

        protected override MagicEffect[] GetCombination(FireEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.Augmented;

            return new MagicEffect[2] { this, effect };
        }

        protected override MagicEffect[] GetCombination(WaterEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[1] { new SteamEffect() };
        }

        protected override MagicEffect[] GetCombination(EarthEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[2] { this, effect };
        }

        protected override MagicEffect[] GetCombination(AirEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[2] { this, effect };
        }

        protected override MagicEffect[] GetCombination(ThunderEffect effect, out AugmentedStatus status)
        {
            throw new InvalidOperationException();
        }
    }
}