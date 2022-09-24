namespace Game.Model
{
    public class Slice : Attack
    {
        public Slice() : 
            base (nameof(Slice), new PhysicalDamage(Config.Attacks.Slice.BaseDamage), 
                Config.Attacks.Slice.ManaCost, Config.Attacks.Slice.StaminaCost) { }       
    }
}