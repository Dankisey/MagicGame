namespace Game.Model
{
    public sealed class Mana : SpendapleCharacteristic, ISpendable
    {
        public Mana(int maxValue) : base(maxValue) { }      
    }
}