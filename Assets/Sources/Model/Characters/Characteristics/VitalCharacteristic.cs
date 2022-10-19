using System;

namespace Game.Model
{
    public abstract class VitalCharacteristic
    {
        private float NormalizedValue => Value / MaxValue;

        public VitalCharacteristic(int maxValue)
        {
            MaxValue = maxValue;
            Value = maxValue;
        }

        public event Action<float> ValueChanged;

        public int MaxValue { get; protected set; }
        public float Value { get; protected set; }

        public void Regenerate(float amount)
        {
            Value += amount;

            if (Value > MaxValue)
                Value = MaxValue;

            InvokeEvent();
        }

        public void Reset()
        {
            Value = MaxValue;
            InvokeEvent();
        }

        protected void InvokeEvent()
        {
            ValueChanged?.Invoke(NormalizedValue);
        }
    }
}