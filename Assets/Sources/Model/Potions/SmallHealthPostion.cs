namespace Game.Model
{
    public class SmallHealthPostion : RestorePotion
    {
        public SmallHealthPostion() : base(Config.RestorePotions.Small.RestoreAmount, Player.Instance.Health) { }
    }
}