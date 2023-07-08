using System;

namespace Game.Model
{
    public interface ITickable
    {
        void Tick();

        void ForceEnd();
    }
}