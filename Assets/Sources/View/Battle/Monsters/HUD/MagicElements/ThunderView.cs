using Game.Model;

namespace Game.View
{
    public sealed class ThunderView : ElementView
    {
        public override void Init()
        {
            base.Init();
            DamageElement = DamageElements.Thunder;
        }
    }
}