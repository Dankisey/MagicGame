namespace Game.Model
{
    public class LargeHealthPostion : RestorePotion
    {
        public LargeHealthPostion(Player target) : base(Config.RestorePotions.Large.RestoreAmount, target.Health) { }
    }
}