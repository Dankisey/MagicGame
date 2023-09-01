namespace Game.Model
{
    public abstract class SpendableCharacteristic : VitalCharacteristic, ISpendable
    {
        public SpendableCharacteristic(int maxValue) : base(maxValue) { }

        public bool TrySpend(float amount)
        {
            if (Value < amount)
                return false;

            Value -= amount;
            InvokeValueChangedEvent();

            return true;
        }
    }

    public interface ISpendable
    {
        public bool TrySpend(float amount);
    }
}