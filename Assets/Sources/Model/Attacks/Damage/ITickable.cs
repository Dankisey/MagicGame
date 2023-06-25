using System;

namespace Game.Model
{
    public interface ITickable
    {
        public event Action<ITickable> Ended;

        void Tick();

        void ForceEnd();
    }
}