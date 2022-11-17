namespace Game.Model
{
    public abstract class FirstTierEffect : MagicEffect
    {
        protected FirstTierEffect(ElementTypes type, int tickCount) : base(tickCount) => Type = type;

        public ElementTypes Type { get; private set; }

        public override MagicEffect[] Combine(MagicEffect effect, out AugmentedStatus status) => GetCombination((dynamic)effect, out status);
    }
}