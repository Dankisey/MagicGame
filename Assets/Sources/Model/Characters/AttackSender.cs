﻿using System;

namespace Game.Model
{
    public abstract class AttackSender
    {
        public event Action<Attack> AttackSent;

        protected void SendAttack(Attack attack)
        {
            AttackSent?.Invoke(attack);
        }
    }
}