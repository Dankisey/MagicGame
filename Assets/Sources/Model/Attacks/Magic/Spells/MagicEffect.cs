namespace Game.Model
{
    public abstract class MagicEffect : Effect, ICombineable
    {
        protected MagicEffect(int tickCount) : base(tickCount) { }

        public virtual bool CheckMatching(Element element) => true;

        public abstract MagicEffect[] Combine(MagicEffect effect, out AugmentedStatus status);

        protected abstract MagicEffect[] GetCombination(FireEffect effect, out AugmentedStatus status);

        protected abstract MagicEffect[] GetCombination(WaterEffect effect, out AugmentedStatus status);

        protected abstract MagicEffect[] GetCombination(EarthEffect effect, out AugmentedStatus status);

        protected abstract MagicEffect[] GetCombination(AirEffect effect, out AugmentedStatus status);

        protected abstract MagicEffect[] GetCombination(ThunderEffect effect, out AugmentedStatus status);
    }

    public interface ICombineable
    {
        public MagicEffect[] Combine(MagicEffect effect, out AugmentedStatus status);
    }

    public enum AugmentedStatus
    {
        Augmented = 1,
        NotAugmented = 0
    }
}