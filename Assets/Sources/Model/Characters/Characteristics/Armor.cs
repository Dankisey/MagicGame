namespace Game.Model
{
    public struct Armor
    {
        public Armor(int amount)
        {
            Amount = amount;
        }

        public float Amount { get; private set; }

        public float GetModifiedDamage(float damage)
        {
            float damagePercent = damage / 100;
            damage -= damagePercent * Amount;

            return damage;
        }
    }
}