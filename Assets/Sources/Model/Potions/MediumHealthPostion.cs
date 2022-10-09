namespace Game.Model
{
    public class MediumHealthPostion : RestorePotion
    {
        public MediumHealthPostion() : base(Config.RestorePotions.Medium.RestoreAmount, Player.Instance.Health) { }
    }
}