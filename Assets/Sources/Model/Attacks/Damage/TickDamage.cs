using System;

namespace Game.Model
{
    public sealed class TickDamage : Damage, ITickable
    {
        public TickDamage(float amount, DamageElements[] elements, int tickAmount) : base(amount, elements)
        {
            TickAmount = tickAmount;
        }

        public int TickAmount { get; private set; }

        public event Action<TickDamage> Ended;

        public void Tick()
        {
            TickAmount--;

            if (TickAmount <= 0)
                Ended?.Invoke(this);
        }

        public void ForceEnd()
        {
            TickAmount = 0;
            Ended?.Invoke(this);
        }
    }
}