namespace Game.Model
{
    public abstract class Attack 
    {
        public Attack(string name, Damage damage, int manaCost, int staminaCost)
        {
            Name = name;
            Damage = damage;
            ManaCost = manaCost;
            StaminaCost = staminaCost;
        }

        public string Name { get; private set; }
        public Damage Damage { get; private set; }
        public int ManaCost { get; private set; }
        public int StaminaCost { get; private set; }
    }

    public interface IAttackPerformer
    {
        public void Perform();
    }
}