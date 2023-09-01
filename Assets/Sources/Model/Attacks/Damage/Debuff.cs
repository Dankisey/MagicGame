using System;

namespace Game.Model
{
    public abstract class Debuff : ITickable, IClonable
    {
        private int _tickAmount;

        public Debuff(int tickAmount, DebuffTypes type)
        {
            _tickAmount = tickAmount;
            Type = type;
        }

        public DebuffTypes Type { get; private set; }

        public event Action<Debuff> Ended;

        public abstract object GetCopy();

        public void Tick()
        {
            _tickAmount--;

            if (_tickAmount <= 0)          
                Ended?.Invoke(this);               
        }

        public void ForceEnd()
        {
            _tickAmount = 0;
            Ended?.Invoke(this);
        }
    }

    public enum DebuffTypes
    {
        None = 0,
    }

    public sealed class EmptyDebuff : Debuff
    {
        public EmptyDebuff() : base(0, DebuffTypes.None) { }

        public override object GetCopy() => new EmptyDebuff();
    }
}