using Game.Model;

namespace Game.View
{
    public sealed class WaterView : ElementView
    {
        public override void Init()
        {
            base.Init();
            DamageElement = DamageElements.Water;
        }
    }
}