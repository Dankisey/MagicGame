namespace Game.Model
{
    public abstract class ThirdTierEffect : MagicEffect
    {
        protected ThirdTierEffect(int tickCount) : base(tickCount) {  }

        public override MagicEffect[] Combine(MagicEffect effect, out AugmentedStatus status)
        {
            status = AugmentedStatus.NotAugmented;

            return new MagicEffect[1] { this };
        }
    }
}