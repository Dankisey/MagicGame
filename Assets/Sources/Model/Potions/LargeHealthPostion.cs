namespace Game.Model
{
    public class LargeHealthPostion : RestorePotion
    {
        public LargeHealthPostion() : base(Config.RestorePotions.Large.RestoreAmount, Player.Instance.Health) { }
    }
}