namespace Game.Model
{
    public abstract class SpendapleCharacteristic : VitalCharacteristic, ISpendable
    {
        public SpendapleCharacteristic(int maxValue) : base(maxValue) { }

        public bool TrySpend(float amount)
        {
            if (Value < amount)
                return false;

            Value -= amount;
            InvokeEvent();

            return true;
        }
    }

    public interface ISpendable
    {
        public bool TrySpend(float amount);
    }
}