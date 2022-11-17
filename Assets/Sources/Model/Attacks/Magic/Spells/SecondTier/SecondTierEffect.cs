namespace Game.Model
{
    public abstract class SecondTierEffect : MagicEffect
    {
        protected SecondTierEffect(SecondTierElementTypes type, int tickCount) : base (tickCount) => Type = type;

        public SecondTierElementTypes Type { get; private set; }

        public override MagicEffect[] Combine(MagicEffect spell, out AugmentedStatus status) => GetCombination((dynamic)spell, out status);
    }
}