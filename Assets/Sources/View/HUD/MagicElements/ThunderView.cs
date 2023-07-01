using Game.Model;

namespace Game.View
{
    public sealed class ThunderView : ElementView
    {
        protected override void Init()
        {
            DamageElement = DamageElements.Thunder;
        }
    }
}