namespace Game.Model
{
    public sealed class Earth : Element
    {
        public Earth() : base(ElementTypes.Earth) { }

        public override FirstTierSpell GetSpell() => new EarthSpell();
    }  
}