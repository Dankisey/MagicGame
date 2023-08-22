namespace Game.Model
{
    public class MediumHealthPostion : RestorePotion
    {
        public MediumHealthPostion(Player target) : base(Config.RestorePotions.Medium.RestoreAmount, target.Health) { }
    }
}