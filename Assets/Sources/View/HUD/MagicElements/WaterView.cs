using Game.Model;

namespace Game.View
{
    public sealed class WaterView : ElementView
    {
        protected override void Init()
        {
            DamageElement = DamageElements.Water;
        }
    }
}