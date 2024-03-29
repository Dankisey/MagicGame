﻿using System;

namespace Game.Model
{
    public abstract class Debuff : ITickable
    {
        private int _tickAmount;

        public Debuff(int tickAmount, DebuffTypes type)
        {
            _tickAmount = tickAmount;
            Type = type;
        }

        public DebuffTypes Type { get; private set; }

        public event Action<Debuff> Ended;

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
}