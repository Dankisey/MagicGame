using Game.Model;

namespace Game.View
{
    public sealed class FireView : ElementView
    {
        protected override void Init()
        {
            DamageElement = DamageElements.Fire;
        }
    }
}