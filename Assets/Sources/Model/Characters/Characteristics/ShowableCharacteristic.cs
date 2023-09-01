using System;

namespace Game.Model
{
    public abstract class ShowableCharacteristic
    {
        private float NormalizedValue => Value / MaxValue;

        public ShowableCharacteristic(int maxValue)
        {
            MaxValue = maxValue;
            Value = 0;
        }

        public event Action<float> ValueChanged;

        public int MaxValue { get; protected set; }
        public float Value { get; protected set; }

        public virtual void Reset()
        {
            Value = 0;
            InvokeValueChangedEvent();
        }

        protected void InvokeValueChangedEvent()
        {
            ValueChanged?.Invoke(NormalizedValue);
        }
    }
}