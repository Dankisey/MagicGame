using System;
using System.Collections.Generic;

namespace Game.Model
{
    public abstract class VitalCharacteristic
    {
        private readonly List<Action> _listenersActions;

        public VitalCharacteristic(int maxValue)
        {
            _listenersActions = new();
            MaxValue = maxValue;
            Value = maxValue;
        }

        ~VitalCharacteristic()
        {
            foreach (var listenerAction in _listenersActions)
            {
                ValueChanged -= listenerAction;
                _listenersActions.Remove(listenerAction);
            }
        }

        private event Action ValueChanged;

        public float Value { get; protected set; }
        public int MaxValue { get; protected set; }

        public float NormalizedValue => Value / MaxValue;

        public void Regenerate(float amount)
        {
            Value += amount;

            if (Value > MaxValue)
                Value = MaxValue;

            InvokeEvent();
        }

        public void AddValueChangedListener(Action listenerAction)
        {
            ValueChanged += listenerAction;
            _listenersActions.Add(listenerAction);
        }

        protected void InvokeEvent()
        {
            ValueChanged.Invoke();
        }
    }
}