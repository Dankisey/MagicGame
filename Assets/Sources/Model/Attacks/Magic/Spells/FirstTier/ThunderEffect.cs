using System;

namespace Game.Model
{
    public sealed class ThunderEffect : FirstTierEffect
    {
        public ThunderEffect() : base(ElementTypes.Thunder, Config.Magic.Effects.Thunder.TickCount) => Potency = Config.Magic.Effects.Thunder.Potency;

        public override int Potency { get; }

        public override bool CheckMatching(Element element)
        {
            if (element is Water || element is Fire)
                return false;
            
            return true;
        }

        protected override MagicEffect[] GetCombination(FireEffect effect, out AugmentedStatus status)
        {
            throw new InvalidOperationException();
        }

        protected override MagicEffect[] GetCombination(WaterEffect effect, out AugmentedStatus status)
        {
            throw new InvalidOperationException();
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
            status = AugmentedStatus.Augmented;

            return new MagicEffect[2] { this, effect };
        }
    }
}