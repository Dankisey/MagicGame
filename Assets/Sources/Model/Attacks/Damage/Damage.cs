﻿using System;
using System.Collections.Generic;

namespace Game.Model
{
    public abstract class Damage
    {
        private readonly DamageElements[] _elements;

        public Damage(float amount, DamageElements[] elements)
        {
            Amount = amount;
            _elements = elements;

            if (elements.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(elements));
        }

        public IReadOnlyList<DamageElements> Elements => _elements;
        public float Amount { get; private set; }
    }

    public enum DamageElements
    {      
        Pure,
        Physical,
        None = 10,
        Fire,
        Water,
        Air,
        Earth,
        Thunder
    }
}