using Game.Model;

namespace Game.View
{
    public sealed class AirView : ElementView
    {
        public override void Init()
        {
            base.Init();
            DamageElement = DamageElements.Air;
        }
    }
}