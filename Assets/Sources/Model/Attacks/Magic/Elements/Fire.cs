namespace Game.Model
{
    public sealed class Fire : Element   
    {
        public Fire() : base(ElementTypes.Fire) { }

        public override FirstTierSpell GetSpell() => new FireSpell();
    }   
}