using System;

namespace Game.Model
{
    public abstract class Debuff : ITickable
    {
        private int _tickAmount;

        public Debuff(int tickAmount)
        {
            _tickAmount = tickAmount;
        }

        public event Action<ITickable> Ended;

        public void Tick()
        {
            if (_tickAmount >= 1)
            {
                _tickAmount--;
            }
            else
            {
                _tickAmount = 0;
                Ended?.Invoke(this);
            }
        }

        public void ForceEnd()
        {
            _tickAmount = 0;
            Ended?.Invoke(this);
        }
    }
}