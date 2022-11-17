namespace Game.Model
{
    public abstract class Effect 
    {
        public Effect(int tickCount) => TickCount = tickCount;

        public int TickCount { get; private set; }

        public virtual void Tick() => TickCount--;

        public abstract int Potency { get; }
    }
}