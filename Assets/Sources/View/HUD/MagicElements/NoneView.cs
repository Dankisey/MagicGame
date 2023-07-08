using Game.Model;

namespace Game.View
{
    public sealed class NoneView : ElementView
    {
        public override void Init()
        {
            base.Init();
            DamageElement = DamageElements.None;
        }
    }
}