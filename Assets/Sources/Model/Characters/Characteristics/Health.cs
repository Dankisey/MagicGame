namespace Game.Model
{
    public sealed class Health : VitalCharacteristic
    {
        public Health(int maxValue) : base(maxValue) { }

        public bool IsAlive => Value > 0;

        public void ApplyDamage(float amount)
        {
            Value -= amount;

            if (Value < 0)           
                Value = 0;

            InvokeEvent();
        }
    }
}