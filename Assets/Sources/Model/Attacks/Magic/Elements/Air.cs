namespace Game.Model
{
    public sealed class Air : Element
    {
        public Air() : base(ElementTypes.Air) { }

        public override FirstTierEffect GetEffect() => new AirEffect();
    }  
}