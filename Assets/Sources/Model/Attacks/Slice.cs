namespace Game.Model
{
    public class Slice : Attack, IAttackPerformer
    {
        public Slice(Character target) : 
            base (nameof(Slice), new PhysicalDamage(Config.Attacks.Slice.BaseDamage), 
                Config.Attacks.Slice.ManaCost, Config.Attacks.Slice.StaminaCost) { }

        public void Perform()
        {

        }
    }
}