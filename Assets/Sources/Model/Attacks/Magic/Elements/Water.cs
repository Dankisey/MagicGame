namespace Game.Model
{
    public sealed class Water : Element
    {
        public Water() : base(ElementTypes.Water) { }

        public override FirstTierEffect GetEffect() => new WaterEffect();
    }  
}