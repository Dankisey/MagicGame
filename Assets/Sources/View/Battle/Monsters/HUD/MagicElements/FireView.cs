using Game.Model;

namespace Game.View
{
    public sealed class FireView : ElementView
    {
        public override void Init()
        {
            base.Init();
            DamageElement = DamageElements.Fire;
        }
    }
}