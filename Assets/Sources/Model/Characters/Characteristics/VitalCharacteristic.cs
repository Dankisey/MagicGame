namespace Game.Model
{
    public abstract class VitalCharacteristic : ShowableCharacteristic
    {
        protected VitalCharacteristic(int maxValue) : base(maxValue) 
        {
            Value = maxValue;
        }

        public void Restore(float amount)
        {
            Value += amount;

            if (Value > MaxValue)
                Value = MaxValue;

            InvokeValueChangedEvent();
        }

        public override void Reset()
        {
            Value = MaxValue;
            InvokeValueChangedEvent();
        }
    }
}