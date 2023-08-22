using Game.Model;

namespace Game.View
{
    public sealed class NoneView : ElementView
    {
        public override DamageElements DamageElement => DamageElements.None;
    }
}