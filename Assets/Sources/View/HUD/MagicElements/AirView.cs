using Game.Model;

namespace Game.View
{
    public sealed class AirView : ElementView
    {
        protected override void Init()
        {
            DamageElement = DamageElements.Air;
        }
    }
}