namespace Game.Model
{
    public sealed class Air : Element
    {
        public Air() : base(ElementTypes.Air) { }

        public override FirstTierSpell GetSpell() => new AirSpell();
    }  
}