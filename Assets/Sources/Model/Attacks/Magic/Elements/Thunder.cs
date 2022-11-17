namespace Game.Model
{
    public sealed class Thunder : Element
    {
        public Thunder() : base(ElementTypes.Thunder) { }

        public override FirstTierEffect GetEffect() => new ThunderEffect();
    }
}