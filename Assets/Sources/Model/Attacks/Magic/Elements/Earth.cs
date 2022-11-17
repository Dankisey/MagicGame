namespace Game.Model
{
    public sealed class Earth : Element
    {
        public Earth() : base(ElementTypes.Earth) { }

        public override FirstTierEffect GetEffect() => new EarthEffect();
    }  
}