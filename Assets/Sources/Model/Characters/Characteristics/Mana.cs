namespace Game.Model
{
    public sealed class Mana : SpendableCharacteristic, ISpendable
    {
        public Mana(int maxValue) : base(maxValue) { }      
    }
}