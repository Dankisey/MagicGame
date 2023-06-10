using System;
using System.Xml.Linq;

namespace Game.Model
{
    public sealed class TickDamage : Damage
    {
        public TickDamage(float amount, DamageElements[] elements, int tickCount) : base(amount, elements)
        {
            TickCount = tickCount;
        }

        public int TickCount { get; private set; }

        public event Action<TickDamage> Ended;

        public Damage Tick()
        {
            TickCount--;

            if (TickCount <= 0)
                Ended?.Invoke(this);

            return new PureDamage(Amount);
        }
    }
}