namespace Game.Model
{
    public class SmallHealthPostion : RestorePotion
    {
        public SmallHealthPostion(Player target) : base(Config.RestorePotions.Small.RestoreAmount, target.Health) { }
    }
}